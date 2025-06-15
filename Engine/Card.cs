using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card(bool tapped, List<Civilization> civilizations, int manaCost, bool summoningSickness) :
        ICopyable<Card>
    {
        readonly IList<Race> addedRaces = [];
        IList<Race> printedRaces = [];

        public IList<IAbility> AddedAbilities { get; } = [];
        readonly CardType cardType;
        public List<Civilization> Civilizations { get; } = civilizations;
        public bool FaceDown { get; private set; }
        public Guid Id { get; } = Guid.NewGuid();
        public bool LostInBattle { get; private set; }
        public int ManaCost { get; } = manaCost;
        public string Name { get; }
        /// <summary>
        /// Id of the card this card is on top of.
        /// </summary>
        public Card OnTopOf { get; private set; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Player Owner { get; }
        public PlayerV2 OwnerV2 { get; }
        public int PhysicalCardId { get; }
        public int? Power { get; private set; }
        public IList<IAbility> PrintedAbilities { get; } = [];
        public int? PrintedPower { get; }
        public List<Race> Races { get; private set; } = [];
        public string RulesText { get; private set; }
        public bool ShieldTrigger { get; private set; }
        public bool SummoningSickness { get; private set; } = summoningSickness;
        public List<Supertype> Supertypes { get; } = [];
        public bool Tapped { get; private set; } = tapped;
        public int Timestamp { get; private set; }
        /// <summary>
        /// The card this card is underneath of.
        /// </summary>
        public Card Underneath { get; private set; }

        protected Card(Card card, int timeStamp) : this(card.Tapped, [.. card.Civilizations], card.ManaCost,
            card.SummoningSickness)
        {
            AddedAbilities = [.. card.AddedAbilities.Select(x => x.Copy())];
            cardType = card.cardType;
            FaceDown = card.FaceDown;
            Id = Guid.NewGuid();
            Name = card.Name;
            OnTopOf = card.OnTopOf;
            Owner = card.Owner;
            OwnerV2 = card.OwnerV2;
            PhysicalCardId = card.PhysicalCardId;
            Power = card.Power;
            PrintedAbilities = [.. card.PrintedAbilities.Select(x => x.Copy())];
            PrintedPower = card.PrintedPower;
            Races = card.Races?.ToList();
            RulesText = card.RulesText;
            ShieldTrigger = card.ShieldTrigger;
            Supertypes = card.Supertypes?.ToList();
            Timestamp = timeStamp; // 613.7d An object receives a timestamp at the time it enters a zone.
            Underneath = card.Underneath;
            InitializeAbilities();
        }

        protected Card(CardType type, string name, int manaCost, int? power, params Civilization[] civilizations) :
            this(false, [.. civilizations], manaCost, summoningSickness: true)
        {
            cardType = type;
            Name = name;
            PrintedPower = power;
        }

        protected Card(Card card) : this(card, 0)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Card c
                && c.AddedAbilities.SequenceEqual(AddedAbilities)
                && c.addedRaces.SequenceEqual(addedRaces)
                && c.cardType == cardType
                && c.Civilizations.SequenceEqual(Civilizations)
                && c.FaceDown == FaceDown
                && c.Id == Id
                && c.LostInBattle == LostInBattle
                && c.ManaCost == ManaCost
                && c.Name == Name
                && c.OnTopOf == OnTopOf
                && c.Owner == Owner
                && c.OwnerV2 == OwnerV2
                && c.PhysicalCardId == PhysicalCardId
                && c.Power == Power
                && c.PrintedAbilities.SequenceEqual(PrintedAbilities)
                && c.PrintedPower == PrintedPower
                && c.printedRaces.SequenceEqual(printedRaces)
                && c.Races.SequenceEqual(Races)
                && c.RulesText == RulesText
                && c.ShieldTrigger == ShieldTrigger
                && c.SummoningSickness == SummoningSickness
                && c.Supertypes.SequenceEqual(Supertypes)
                && c.Tapped == Tapped
                && c.Timestamp == Timestamp
                && c.Underneath == Underneath;
        }

        public bool IsSpell => cardType == CardType.Spell;
        public bool IsCreature => cardType == CardType.Creature;
        public bool IsNonEvolutionCreature => IsCreature && !Supertypes.Contains(Supertype.Evolution);
        public bool IsEvolutionCreature => IsCreature && Supertypes.Contains(Supertype.Evolution);
        public bool IsMultiColored => Civilizations.Count > 1;
        public bool IsDragon => IsCreature && Races.Intersect([Race.EarthDragon, Race.ZombieDragon, Race.ArmoredDragon,
            Race.VolcanoDragon ]).Any();
        internal bool CountsAsIfExists => Underneath != null;
        IEnumerable<IAbility> Abilities => PrintedAbilities.Union(AddedAbilities);

        public void AddGrantedAbility(IAbility ability)
        {
            AddedAbilities.Add(ability);
        }

        public void AddGrantedRace(Race race)
        {
            addedRaces.Add(race);
            if (!Races.Contains(race))
            {
                Races.Add(race);
            }
        }

        public Card Copy()
        {
            return new Card(this);
        }

        public IList<Card> Deconstruct(IList<Card> deconstructred)
        {
            if (Underneath != null)
            {
                var list = deconstructred.ToList();
                list.AddRange(Underneath.Deconstruct(deconstructred));
                Underneath = null;
                return list;
            }
            else
            {
                OnTopOf = null;
                return [this];
            }
        }

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }

        public bool HasCivilization(params Civilization[] civilizations)
        {
            return Civilizations.Intersect(civilizations).Any();
        }

        public bool HasRace(Race race)
        {
            return Races.Contains(race);
        }

        /// <summary>
        /// Initializes the sources and controllers of all abilities and related abstractions of the card.
        /// </summary>
        public void InitializeAbilities()
        {
            Abilities.ToList().ForEach(x => InitializeAbility(x));
            SetRulesText();
        }

        public void PutOnTopOf(IEnumerable<Card> baits)
        {
            var remainingBaits = baits.ToList();
            List<Card> toBeStacked = [];
            while (remainingBaits.Count > 1)
            {
                var card = Owner.ChooseCard(remainingBaits, "Choose a card to be placed on a stack of cards. (the remaining cards will be stacked on top of it)");
                toBeStacked.Add(card);
                remainingBaits.Remove(card);
            }
            toBeStacked.Add(remainingBaits.Single());
            toBeStacked.Add(this);
            for (int i = 1; i < toBeStacked.Count; ++i)
            {
                var bait = toBeStacked.ElementAt(i - 1);
                OnTopOf = bait;
                bait.Underneath = this;
            }
        }

        public void ResetToPrintedValues()
        {
            Power = PrintedPower;
            AddedAbilities.Clear();
            Races = [.. printedRaces];
            addedRaces.Clear();
        }

        public void SeparateTopCard()
        {
            if (OnTopOf != null)
            {
                var card = OnTopOf;
                OnTopOf = null;
                card.Underneath = null;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({PhysicalCardId})";
        }

        protected void AddAbilities(params IAbility[] abilities)
        {
            abilities.ToList().ForEach(x => PrintedAbilities.Add(x));
        }

        protected void SetPrintedRaces(params Race[] races)
        {
            printedRaces = races;
            Races = [.. races];
        }

        void InitializeAbility(IAbility ability)
        {
            ability.Controller = Owner;
            ability.Source = this;
        }

        void SetRulesText()
        {
            RulesText = string.Join("\r\n", Abilities.Select(x => x.ToString()));
        }

        public IEnumerable<TapAbility> GetTapAbilities()
        {
            return GetAbilities<TapAbility>();
        }

        public IEnumerable<SilentSkillAbility> GetSilentSkillAbilities()
        {
            return GetAbilities<SilentSkillAbility>();
        }

        protected void AddShieldTrigger()
        {
            ShieldTrigger = true;
        }

        /// <summary>
        /// Creates a static ability for each continuous effect provided and add the abilities to the card.
        /// </summary>
        /// <param name="effects"></param>
        protected void AddStaticAbilities(params Engine.ContinuousEffects.IContinuousEffect[] effects)
        {
            AddAbilities(effects.Select(x => new StaticAbility(x)).ToArray());
        }

        public IEnumerable<IEvolutionEffect> GetEvolutionEffects()
        {
            return GetAbilities<IStaticAbility>().Select(x => x.ContinuousEffects).OfType<IEvolutionEffect>();
        }

        internal void Tap()
        {
            Tapped = true;
        }

        public void TurnFaceUp()
        {
            FaceDown = false;
        }

        internal void RemoveSummoningSickness()
        {
            SummoningSickness = false;
        }

        internal void SetLostInBattle()
        {
            LostInBattle = true;
        }

        public void IncreasePower(int power)
        {
            Power += power;
        }

        internal void SetTimestamp(int timestamp)
        {
            Timestamp = timestamp;
        }
    }
}