using Combinatorics.Collections;
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
        public Deck Deck { get; set; }

        public abstract YesNoDecision Choose(YesNoChoice yesNoChoice);

        public void Tap(Game game, object toarray)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public Graveyard Graveyard { get; private set; } = new Graveyard(new List<Card>());

        public abstract GuidDecision Choose(GuidSelection guidSelection);

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public Hand Hand { get; private set; } = new Hand(new List<Card>());

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public ManaZone ManaZone { get; private set; } = new ManaZone(new List<Card>());

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public ShieldZone ShieldZone { get; private set; } = new ShieldZone(new List<Card>());

        public IEnumerable<Card> CardsInNonsharedZones
        {
            get
            {
                List<Card> cards = new List<Card>();
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

        private static readonly Random _random = new Random();

        #region Methods
        protected Player()
        {
        }

        protected Player(Player player) : base(player)
        {
            Deck = player.Deck.Copy() as Deck;
            Graveyard = player.Graveyard.Copy() as Graveyard;
            Hand = player.Hand.Copy() as Hand;
            ManaZone = player.ManaZone.Copy() as ManaZone;
            ShieldZone = player.ShieldZone.Copy() as ShieldZone;
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
                game.PreGameEvents.Enqueue(eve);
            }
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, Game game)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(Deck.Cards.Last(), ZoneType.Deck, ZoneType.ShieldZone);
                }
            }
        }

        private void Summon(Card card, Game game)
        {
            game.Process(new CreatureSummonedEvent { Player = Copy(), Creature = card.Convert() });
            _ = game.Move(new List<Card> { card }, ZoneType.Hand, ZoneType.BattleZone);
        }

        public void DrawCards(int amount, Game game)
        {
            // 121.2. Cards may only be drawn one at a time. If a player is instructed to draw multiple cards, that player performs that many individual card draws.
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(Deck.Cards.Last(), ZoneType.Deck, ZoneType.Hand);
                }
            }
        }

        internal IEnumerable<Card> GetUsableCards()
        {
            return Hand.Cards.Where(card => card.ManaCost <= ManaZone.UntappedCards.Count() && HasCivilizations(ManaZone.UntappedCards, card.Civilizations));
        }

        internal IEnumerable<IEnumerable<Card>> GetManaCombinations(Card card)
        {
            return new Combinations<Card>(ManaZone.UntappedCards, card.ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, card.Civilizations));//.Select(x => x.Select(y => y.Id)));
        }

        private static bool HasCivilizations(IEnumerable<Card> manas, IEnumerable<Civilization> civs)
        {
            if (!civs.Any())
            {
                return true;
            }
            else if (!manas.Any())
            {
                return false;
            }
            else
            {
                return manas.First().Civilizations.Any(x => HasCivilizations(manas.Skip(1), civs.Where(c => c != x)));
            }
        }

        public void PutFromTopOfDeckIntoManaZone(Game game, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(Deck.Cards.Last(), ZoneType.Deck, ZoneType.ManaZone);
                }
            }
        }

        private void Cast(Card spell, Game game)
        {
            Hand.Remove(spell, game);
            spell.RevealedTo = game.Players.Select(x => x.Id).ToList();
            game.Process(new SpellCastEvent(Convert(), spell.Convert()));
            foreach (var ability in spell.Abilities.OfType<SpellAbility>().Select(x => x.Copy()).Cast<SpellAbility>())
            {
                ability.Source = spell.Id;
                ability.Owner = spell.Owner;
                ability.Resolve(game);
            }
            var effects = game.GetContinuousEffects<ChargerEffect>(spell).Union(spell.Abilities.OfType<StaticAbility>().SelectMany(x => x.ContinuousEffects).OfType<ChargerEffect>());

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(spell);
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
            game.Process(new CardMovedEvent { CardInDestinationZone = newObject.Convert(), CardInSourceZone = spell.Id, Destination = destination, Player = Convert(), Source = ZoneType.Anywhere });
        }

        public void DiscardAtRandom(Game game)
        {
            if (Hand.Cards.Any())
            {
                _ = game.Move(new List<Card> { Hand.Cards[_random.Next(Hand.Cards.Count)] }, ZoneType.Hand, ZoneType.Graveyard);
            }
        }

        public void Reveal(Game game, Card card)
        {
            var opponent = game.GetOpponent(this);
            card.RevealedTo.Add(opponent.Id);
            game.Process(new CardRevealedEvent { Player = Copy(), Card = card.Convert() });
        }

        internal Zone GetZone(ZoneType zone)
        {
            switch (zone)
            {
                case ZoneType.Deck:
                    return Deck;
                case ZoneType.Graveyard:
                    return Graveyard;
                case ZoneType.Hand:
                    return Hand;
                case ZoneType.ManaZone:
                    return ManaZone;
                case ZoneType.ShieldZone:
                    return ShieldZone;
                case ZoneType.Anywhere:
                case ZoneType.BattleZone:
                default:
                    throw new InvalidOperationException();
            }
        }

        public Common.Player Copy()
        {
            return Convert();
        }

        private void ChooseCardsToPayManaCost(Game game, Card toUse)
        {
            var manaDecision = Choose(new PaymentSelection(Id, ManaZone.UntappedCards, toUse.ManaCost, toUse.ManaCost)).Decision.Select(x => game.GetCard(x));
            if (HasCivilizations(manaDecision, toUse.Civilizations))
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

        internal bool ChooseCardToUse(Game game, IEnumerable<Card> cards)
        {
            var decision = Choose(new UseCardSelection(Id, cards)).Decision;
            if (decision.Any())
            {
                var id = decision.Single();
                var toUse = cards.Single(x => x.Id == id);
                var manaCombinations = GetManaCombinations(toUse);
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
        #endregion Methods
    }
}