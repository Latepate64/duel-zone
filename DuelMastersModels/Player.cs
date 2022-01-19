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
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public abstract class Player : IAttackable, IDisposable, ICopyable<Player>
    {
        #region Properties
        public Guid Id { get; }

        public string Name { get; set; }

        public abstract CardUsageDecision Choose(CardUsageChoice cardUsageChoice);

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

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; set; } = new BattleZone(new List<Card>());

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

        public IEnumerable<Card> AllCards
        {
            get
            {
                List<Card> cards = CardsInNonsharedZones.ToList();
                cards.AddRange(BattleZone.Cards);
                return cards;
            }
        }

        public IEnumerable<Zone> Zones => new List<Zone> { Deck, Graveyard, Hand, ManaZone, ShieldZone, BattleZone };
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
            BattleZone = player.BattleZone.Copy() as BattleZone;
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
                BattleZone?.Dispose();
                BattleZone = null;
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

        public void ShuffleDeck(Duel duel)
        {
            Deck.Shuffle();
            var eve = new DeckShuffledEvent(Copy());
            if (duel.Turns.Any())
            {
                duel.Process(eve);
            }
            else
            {
                duel.PreGameEvents.Enqueue(eve);
            }
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, Duel duel)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    duel.Move(Deck.Cards.Last(), ZoneType.Deck, ZoneType.ShieldZone);
                }
            }
        }

        internal void Summon(Card card, Duel duel)
        {
            duel.Process(new CreatureSummonedEvent(Copy(), new Card(card, true)));
            _ = duel.Move(new List<Card> { card }, ZoneType.Hand, ZoneType.BattleZone);
        }

        public void DrawCards(int amount, Duel duel)
        {
            // 121.2.Cards may only be drawn one at a time. If a player is instructed to draw multiple cards, that player performs that many individual card draws.
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    duel.Move(Deck.Cards.Last(), ZoneType.Deck, ZoneType.Hand);
                }
            }
        }

        public void UntapCardsInBattleZoneAndManaZone()
        {
            BattleZone.UntapCards();
            ManaZone.UntapCards();
        }

        internal IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> GetUsableCardsWithPaymentInformation()
        {
            return Hand.Cards.Distinct(new CardComparer()).
                Where(card => card.ManaCost <= ManaZone.UntappedCards.Count() && HasCivilizations(ManaZone.UntappedCards, card.Civilizations)).
                GroupBy(
                    card => card.Id,
                    card => new Combinations<Card>(ManaZone.UntappedCards, card.ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, card.Civilizations)).Select(x => x.Select(y => y.Id)));
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

        public void PutFromTopOfDeckIntoManaZone(Duel duel)
        {
            if (Deck.Cards.Any())
            {
                duel.Move(Deck.Cards.Last(), ZoneType.Deck, ZoneType.ManaZone);
            }
        }

        internal void Cast(Card spell, Duel duel)
        {
            Hand.Remove(spell, duel);
            spell.RevealedTo = duel.Players.Select(x => x.Id).ToList();
            duel.Process(new SpellCastEvent(Copy(), new Card(spell, true)));
            foreach (var ability in spell.Abilities.OfType<SpellAbility>().Select(x => x.Copy()).Cast<SpellAbility>())
            {
                ability.Source = spell.Id;
                ability.Owner = spell.Owner;
                ability.Resolve(duel);
            }
            var effects = duel.GetContinuousEffects<ChargerEffect>(spell).Union(spell.Abilities.OfType<StaticAbility>().SelectMany(x => x.ContinuousEffects).OfType<ChargerEffect>());
            if (effects.Any())
            {
                duel.GetPlayer(spell.Owner).ManaZone.Add(spell, duel);
            }
            else
            {
                duel.GetPlayer(spell.Owner).Graveyard.Add(spell, duel);

            }
        }

        public void DiscardAtRandom(Duel duel)
        {
            if (Hand.Cards.Any())
            {
                duel.Discard(new List<Card> { Hand.Cards[_random.Next(Hand.Cards.Count)] });
            }
        }

        public void Reveal(Duel duel, Card card)
        {
            var opponent = duel.GetOpponent(this);
            card.RevealedTo.Add(opponent.Id);
            duel.Process(new CardRevealedEvent(Copy(), new Card(card, true)));
        }

        public Zone GetZone(ZoneType zone)
        {
            switch (zone)
            {
                case ZoneType.BattleZone:
                    return BattleZone;
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
                default:
                    throw new InvalidOperationException();
            }
        }

        public abstract Player Copy();
        #endregion Methods
    }
}