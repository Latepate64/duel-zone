﻿using Combinatorics.Collections;
using Common;
using Common.GameEvents;
using Engine.Abilities;
using Common.Choices;
using Engine.ContinuousEffects;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    /// <summary>
    /// 102.1. A player is one of the people in the game.
    /// </summary>
    public abstract class Player : Common.Player, IAttackable, IDisposable//, ICopyable<Player>
    {
        #region Properties
        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public Deck Deck { get; private set; } = new();

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public Graveyard Graveyard { get; private set; } = new();

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public Hand Hand { get; private set; } = new();

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public ManaZone ManaZone { get; private set; } = new();

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public ShieldZone ShieldZone { get; private set; } = new();

        public IEnumerable<Card> CardsInNonsharedZones
        {
            get
            {
                List<Card> cards = new();
                cards.AddRange(Deck.Cards);
                cards.AddRange(Graveyard.Cards);
                cards.AddRange(Hand.Cards);
                cards.AddRange(ManaZone.Cards);
                cards.AddRange(ShieldZone.Cards);
                return cards;
            }
        }

        public IEnumerable<Zone> Zones => new List<Zone> { Deck, Graveyard, Hand, ManaZone, ShieldZone };
        #endregion Properties

        private static readonly Random Random = new();

        #region Methods
        protected Player()
        {
        }

        protected Player(Player player) : base(player)
        {
            Deck = new Deck(player.Deck);
            Graveyard = new Graveyard(player.Graveyard);
            Hand = new Hand(player.Hand);
            ManaZone = new ManaZone(player.ManaZone);
            ShieldZone = new ShieldZone(player.ShieldZone);
        }

        public override string ToString()
        {
            return Name;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Deck?.Dispose();
                Deck = null;
                Graveyard?.Dispose();
                Graveyard = null;
                Hand?.Dispose();
                Hand = null;
                ManaZone?.Dispose();
                ManaZone = null;
                ShieldZone?.Dispose();
                ShieldZone = null;
            }
        }

        public YesNoDecision Choose(YesNoChoice yesNoChoice, Game game)
        {
           var decision = ClientChoose(yesNoChoice);
           if (decision != null)
           {
                return decision;
           }
           else
           {
                Concede(game);
                return new YesNoDecision();
            }
        }

        public abstract YesNoDecision ClientChoose(YesNoChoice yesNoChoice);

        public GuidDecision Choose(GuidSelection selection, Game game)
        {
            var legal = false;
            GuidDecision decision = null;
            while (!legal)
            {
                decision = ClientChoose(selection);
                if (decision != null)
                {
                    var dist = decision.Decision.Distinct();
                    legal = selection.IsLegal(dist);
                }
                else
                {
                    Concede(game);
                    return new GuidDecision();
                }
            }
            return decision;
        }

        public abstract GuidDecision ClientChoose(GuidSelection guidSelection);

        public void ShuffleDeck(Game game)
        {
            Deck.Shuffle();
            var eve = new DeckShuffledEvent { Player = Copy() };
            if (game.Turns.Any())
            {
                game.Process(eve);
            }
            else
            {
                game._preGameEvents.Enqueue(eve);
            }
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, Game game)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(ZoneType.Deck, ZoneType.ShieldZone, Deck.Cards.Last());
                }
            }
        }

        private void Summon(Card card, Game game)
        {
            game.Process(new CreatureSummonedEvent { Player = Copy(), Creature = card.Convert() });
            _ = game.Move(ZoneType.Hand, ZoneType.BattleZone, card);
        }

        public void DrawCards(int amount, Game game)
        {
            // 121.2. Cards may only be drawn one at a time.
            // If a player is instructed to draw multiple cards,
            // that player performs that many individual card draws.
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(ZoneType.Deck, ZoneType.Hand, Deck.Cards.Last());
                }
            }
        }

        internal IEnumerable<Card> GetCardsThatCanBePaid()
        {
            return Hand.Cards.Where(card => card.CanBePaid(this));
        }

        internal IEnumerable<Card> GetCardsThatCanBePaidAndUsed(Game game)
        {
            return GetCardsThatCanBePaid().Where(x => x.CanBeUsedRegardlessOfManaCost(game));
        }

        public void PutFromTopOfDeckIntoManaZone(Game game, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(ZoneType.Deck, ZoneType.ManaZone, Deck.Cards.Last());
                }
            }
        }

        private void Cast(Card spell, Game game)
        {
            Hand.Remove(spell, game);
            spell.KnownTo = game.Players.Select(x => x.Id).ToList();
            game.Process(new SpellCastEvent(Convert(), spell.Convert()));
            foreach (var ability in spell.GetAbilities<SpellAbility>().Select(x => x.Copy()).Cast<SpellAbility>())
            {
                ability.Source = spell.Id;
                ability.Owner = spell.Owner;
                ability.Resolve(game);
            }
            var effects = game.GetContinuousEffects<ChargerEffect>(spell).Union(spell.GetAbilities<StaticAbility>().SelectMany(x => x.ContinuousEffects).OfType<ChargerEffect>());

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(spell, game.GetTimestamp());
            ZoneType destination;
            if (effects.Any())
            {
                game.GetPlayer(newObject.Owner)?.ManaZone.Add(newObject, game);
                destination = ZoneType.ManaZone;
            }
            else
            {
                game.GetPlayer(newObject.Owner)?.Graveyard.Add(newObject, game);
                destination = ZoneType.Graveyard;
            }
            game.Process(new CardMovedEvent { Card = newObject.Convert(), CardInSourceZone = spell.Id, Destination = destination, Player = Convert(), Source = ZoneType.Anywhere });
        }

        public void DiscardAtRandom(Game game, int amount)
        {
            if (Hand.Cards.Any())
            {
                _ = game.Move(ZoneType.Hand, ZoneType.Graveyard, Hand.Cards.OrderBy(x => Guid.NewGuid()).Take(amount).ToArray());
            }
        }

        public void Reveal(Game game, Card card)
        {
            var opponent = game.GetOpponent(this);
            card.KnownTo.Add(opponent.Id);
            game.Process(new CardRevealedEvent { Player = Copy(), Card = card.Convert() });
        }

        internal Zone GetZone(ZoneType zone)
        {
            return zone switch
            {
                ZoneType.Deck => Deck,
                ZoneType.Graveyard => Graveyard,
                ZoneType.Hand => Hand,
                ZoneType.ManaZone => ManaZone,
                ZoneType.ShieldZone => ShieldZone,
                _ => throw new InvalidOperationException(),
            };
        }

        public Common.Player Copy()
        {
            return Convert();
        }

        private void ChooseCardsToPayManaCost(Game game, Card toUse)
        {
            var manaDecision = Choose(new PaymentSelection(Id, ManaZone.UntappedCards, toUse.ManaCost, toUse.ManaCost), game).Decision.Select(x => game.GetCard(x));
            if (Card.HasCivilizations(manaDecision, toUse.Civilizations))
            {
                PayManaCostAndUseCard(game, manaDecision, toUse);
            }
            else
            {
                ChooseCardsToPayManaCost(game, toUse);
            }
        }

        private void PayManaCostAndUseCard(Game game, IEnumerable<Card> manaCards, Card toUse)
        {
            Tap(game, manaCards.ToArray());
            UseCard(toUse, game);
        }

        internal bool ChooseCardToUse(Game game, IEnumerable<Card> usableCards)
        {
            var decision = Choose(new UseCardSelection(Id, usableCards), game).Decision;
            if (decision.Any())
            {
                var id = decision.Single();
                var toUse = usableCards.Single(x => x.Id == id);
                var manaCombinations = toUse.GetManaCombinations(this);
                if (manaCombinations.Count() > 1)
                {
                    ChooseCardsToPayManaCost(game, toUse);
                }
                else
                {
                    PayManaCostAndUseCard(game, manaCombinations.Single(), toUse);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void UseCard(Card card, Game game)
        {
            game.CurrentTurn.CurrentPhase.UsedCards.Add(card.Copy());
            if (card.CardType == CardType.Creature)
            {
                if (card.Supertypes.Contains(Supertype.Evolution))
                {
                    Evolve(card, game);
                }
                Summon(card, game);
            }
            else if (card.CardType == CardType.Spell)
            {
                Cast(card, game);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void Evolve(Card card, Game game)
        {
            var baits = game.GetCreaturesCreatureCanEvolveFrom(card);
            var bait = game.GetCard(Choose(new EvolutionBaitSelection(Id, baits), game).Decision.Single());
            card.PutOnTopOf(bait);
        }

        public Common.Player Convert()
        {
            return new Common.Player(this);
        }

        public void Tap(Game game, params Card[] cards)
        {
            var untappedCards = cards.Where(x => !x.Tapped).ToList();
            foreach (Card card in untappedCards)
            {
                card.Tapped = true;
            }
            if (untappedCards.Any())
            {
                game.Process(new TapEvent(Convert(), untappedCards.Select(x => x.Convert()).ToList(), true));
            }
        }

        public void Untap(Game game, params Card[] cards)
        {
            var tappedCards = cards.Where(x => x.Tapped).ToList();
            foreach (Card card in tappedCards)
            {
                card.Tapped = false;
            }
            if (tappedCards.Any())
            {
                game.Process(new TapEvent(Convert(), tappedCards.Select(x => x.Convert()).ToList(), false));
            }
        }

        /// <summary>
        /// 104.3a A player can concede the game at any time.
        /// A player who concedes leaves the game immediately.
        /// That player loses the game.
        /// </summary>
        /// <param name="game"></param>
        private void Concede(Game game)
        {
            game.Process(new ConcedeEvent { Player = Convert() });
            game.Lose(this);
        }

        public void Look(Card[] cards)
        {
            cards.Where(x => !x.KnownTo.Contains(Id)).ToList().ForEach(x => x.KnownTo.Add(Id));
        }
        #endregion Methods
    }
}