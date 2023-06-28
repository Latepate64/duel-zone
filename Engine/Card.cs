using Combinatorics.Collections;
using Engine.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    abstract public class Card : ICard, ICopyable<ICard>, ITimestampable
    {
        private readonly IList<Race> _addedRaces = new List<Race>();
        private IList<Race> _printedRaces = new List<Race>();
        public Card()
        {
            Id = Guid.NewGuid();
        }

        protected Card(ICard card, int timeStamp)
        {
            AddedAbilities = card.AddedAbilities.Select(x => x.Copy()).ToList();
            CardType = card.CardType;
            Civilizations = card.Civilizations.ToList();
            FaceDown = card.FaceDown;
            Id = Guid.NewGuid();
            KnownTo = card.KnownTo.ToList();
            ManaCost = card.ManaCost;
            Name = card.Name;
            OnTopOf = card.OnTopOf;
            Owner = card.Owner;
            Power = card.Power;
            PrintedAbilities = card.PrintedAbilities.Select(x => x.Copy()).ToList();
            PrintedPower = card.PrintedPower;
            Races = card.Races?.ToList();
            RulesText = card.RulesText;
            ShieldTrigger = card.ShieldTrigger;
            SummoningSickness = card.SummoningSickness;
            Supertypes = card.Supertypes?.ToList();
            Tapped = card.Tapped;
            Timestamp = timeStamp; // 613.7d An object receives a timestamp at the time it enters a zone.
            Underneath = card.Underneath;
            InitializeAbilities();
        }

        protected Card(CardType type, string name, int manaCost, int? power, params Civilization[] civilizations) : this()
        {
            CardType = type;
            Civilizations = civilizations.ToList();
            ManaCost = manaCost;
            Name = name;
            PrintedPower = power;
        }

        protected Card(ICard card) : this(card, 0)
        {
        }

        public IList<IAbility> AddedAbilities { get; } = new List<IAbility>();
        public CardType CardType { get; set; }
        public List<Civilization> Civilizations { get; set; } = new();
        /// <summary>
        /// TODO: Apply in logic
        /// </summary>
        public bool FaceDown { get; set; }

        public Guid Id { get; set; }
        public List<Guid> KnownTo { get; set; } = new();
        public bool LostInBattle { get; set; }
        public int ManaCost { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Id of the card this card is on top of.
        /// </summary>
        public ICard OnTopOf { get; set; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public IPlayer Owner { get; set; }
        public int? Power { get; set; }
        public IList<IAbility> PrintedAbilities { get; } = new List<IAbility>();
        public int? PrintedPower { get; }
        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public List<Race> Races { get; set; } = new();

        public string RulesText { get; set; }
        public bool ShieldTrigger { get; set; }
        public bool SummoningSickness { get; set; }
        public List<Supertype> Supertypes { get; set; } = new();
        public bool Tapped { get; set; }
        public int Timestamp { get; set; }
        /// <summary>
        /// The card this card is underneath of.
        /// </summary>
        public ICard Underneath { get; set; }

        internal bool CountsAsIfExists => Underneath != null;
        private IEnumerable<IAbility> Abilities => PrintedAbilities.Union(AddedAbilities);

        public bool IsDragon => Races.Intersect(new Race[] { Race.ArmoredDragon, Race.EarthDragon, Race.VolcanoDragon, Race.ZombieDragon }).Any();
        public bool IsEvolutionCreature => Supertypes.Any(x => x == Supertype.Evolution);
        public bool IsMultiColored => Civilizations.Count > 1;
        public bool IsNonEvolutionCreature => IsCreature && !IsEvolutionCreature;

        public bool IsCreature => CardType == CardType.Creature;
        public bool IsSpell => CardType == CardType.Spell;

        public void AddGrantedAbility(IAbility ability)
        {
            AddedAbilities.Add(ability);
        }

        public void AddGrantedRace(Race race)
        {
            _addedRaces.Add(race);
            if (!Races.Contains(race))
            {
                Races.Add(race);
            }
        }

        public bool CanBePaid(IPlayer player)
        {
            return ManaCost <= player.ManaZone.UntappedCards.Count() && HasCivilizations(player.ManaZone.UntappedCards, Civilizations);
        }

        public abstract ICard Copy();

        public IList<ICard> Deconstruct(IList<ICard> deconstructred)
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
                return new List<ICard> { this };
            }
        }

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }
        public IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player)
        {
            return new Combinations<ICard>(player.ManaZone.UntappedCards, ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, Civilizations));//.Select(x => x.Select(y => y.Id)));
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

        public void PutOnTopOf(IEnumerable<ICard> baits)
        {
            var remainingBaits = baits.ToList();
            List<ICard> toBeStacked = new();
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
            Races = _printedRaces.ToList();
            _addedRaces.Clear();
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
            return Name;
            //return Name + " " + Id.ToString();
        }
        internal static bool HasCivilizations(IEnumerable<ICard> manas, IEnumerable<Civilization> civs)
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

        protected void AddAbilities(params IAbility[] abilities)
        {
            abilities.ToList().ForEach(x => PrintedAbilities.Add(x));
        }

        protected void SetPrintedRaces(params Race[] races)
        {
            _printedRaces = races;
            Races = races.ToList();
        }

        private void InitializeAbility(IAbility ability)
        {
            ability.Controller = Owner;
            ability.Source = this;
        }

        private void SetRulesText()
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
    }
}