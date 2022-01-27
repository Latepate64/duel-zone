using Combinatorics.Collections;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// 102.1. A player is one of the people in the game.
    /// </summary>
    public abstract class Player : IAttackable, IDisposable, ICopyable<Player>
    {
        #region Properties
        public Guid Id { get; }

        public string Name { get; set; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public Deck Deck { get; set; }

        public abstract YesNoDecision Choose(YesNoChoice yesNoChoice);
        public abstract AttackerDecision Choose(AttackerChoice attackerChoice);

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
            Id = Guid.NewGuid();
        }

        protected Player(Player player)
        {
            Id = player.Id;
            Name = player.Name;
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
            var eve = new DeckShuffledEvent(Copy());
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

        internal void Summon(Card card, Game game)
        {
            game.Process(new CreatureSummonedEvent(Copy(), new Card(card, true)));
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

        internal static bool HasCivilizations(IEnumerable<Card> manas, IEnumerable<Civilization> civs)
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

        internal void Cast(Card spell, Game game)
        {
            Hand.Remove(spell, game);
            spell.RevealedTo = game.Players.Select(x => x.Id).ToList();
            game.Process(new SpellCastEvent(Copy(), new Card(spell, true)));
            foreach (var ability in spell.Abilities.OfType<SpellAbility>().Select(x => x.Copy()).Cast<SpellAbility>())
            {
                ability.Source = spell.Id;
                ability.Owner = spell.Owner;
                ability.Resolve(game);
            }
            var effects = game.GetContinuousEffects<ChargerEffect>(spell).Union(spell.Abilities.OfType<StaticAbility>().SelectMany(x => x.ContinuousEffects).OfType<ChargerEffect>());
            if (effects.Any())
            {
                game.GetPlayer(spell.Owner).ManaZone.Add(spell, game);
            }
            else
            {
                game.GetPlayer(spell.Owner).Graveyard.Add(spell, game);

            }
        }

        public void DiscardAtRandom(Game game)
        {
            if (Hand.Cards.Any())
            {
                game.Discard(new List<Card> { Hand.Cards[_random.Next(Hand.Cards.Count)] });
            }
        }

        public void Reveal(Game game, Card card)
        {
            var opponent = game.GetOpponent(this);
            card.RevealedTo.Add(opponent.Id);
            game.Process(new CardRevealedEvent(Copy(), new Card(card, true)));
        }

        public Zone GetZone(ZoneType zone)
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

        public abstract Player Copy();

        private void ChooseCardsToPayManaCost(Game game, Card toUse)
        {
            var manaDecision = Choose(new GuidSelection(Id, ManaZone.UntappedCards, toUse.ManaCost, toUse.ManaCost)).Decision.Select(x => game.GetCard(x));
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
            foreach (Card mana in manaCards)
            {
                mana.Tapped = true;
            }
            game.UseCard(toUse, this);
        }

        internal bool ChooseCardToUse(Game game, IEnumerable<Card> cards)
        {
            var decision = Choose(new GuidSelection(Id, cards, 0, 1)).Decision;
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
        #endregion Methods
    }
}