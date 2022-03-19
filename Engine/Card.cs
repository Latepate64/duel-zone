using Combinatorics.Collections;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : Common.Card, ICopyable<Card>, IAttackable, ITimestampable, ICard
    {
        private IEnumerable<Ability> Abilities => _printedAbilities.Union(_addedAbilities);
        private readonly List<Ability> _printedAbilities = new();
        private readonly List<Ability> _addedAbilities = new();

        private readonly int? _printedPower;

        public int Timestamp { get; }

        internal bool CountsAsIfExists => Underneath != Guid.Empty;

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }

        public Card() { }

        public Card(int? power)
        {
            _printedPower = power;
        }

        internal Card(Card card, int timeStamp) : base(card, false)
        {
            Timestamp = timeStamp; // 613.7d An object receives a timestamp at the time it enters a zone.
            _addedAbilities = card._addedAbilities.Select(x => x.Copy()).ToList();
            _printedAbilities = card._printedAbilities.Select(x => x.Copy()).ToList();
            _printedPower = card._printedPower;
            InitializeAbilities();
        }

        public virtual Card Copy()
        {
            return new Card(this, Timestamp);
        }

        public override string ToString()
        {
            return Name;
            //return Name + " " + Id.ToString();
        }

        /// <summary>
        /// Initializes the sources and controllers of all abilities and related abstractions of the card.
        /// </summary>
        public void InitializeAbilities()
        {
            foreach (var ability in Abilities)
            {
                ability.Owner = Owner;
                ability.Source = Id;
                if (ability is StaticAbility staticAbility)
                {
                    foreach (var effect in staticAbility.ContinuousEffects)
                    {
                        if (effect.Filter is ITargetFilterable target)
                        {
                            target.Target = Id;
                        }
                        effect.SetupConditionFilters(Id);
                    }
                }
                else if (ability is CardTriggeredAbility triggeredAbility && triggeredAbility.Filter is TargetFilter target)
                {
                    target.Target = Id;
                }
            }
            SetRulesText();
        }

        public Common.Card Convert(bool clear = false)
        {
            return new Common.Card(this, clear);
        }

        private void SetRulesText()
        {
            RulesText = string.Join("\r\n", Abilities.Select(x => x.ToString()));
        }

        internal void AddGrantedAbility(Ability ability)
        {
            _addedAbilities.Add(ability);
        }

        protected void AddAbilities(params Ability[] abilities)
        {
            _printedAbilities.AddRange(abilities);
        }

        public bool IsEvolutionCreature => Supertypes.Any(x => x == Common.Supertype.Evolution);

        public Guid AttackableId { get; set; }

        internal void ResetToPrintedValues()
        {
            Power = _printedPower;
            _addedAbilities.Clear();
        }

        public bool CanAttackCreatures(Game game)
        {
            return !game.GetContinuousEffects<CannotAttackCreaturesEffect>(this).Any();
        }

        public bool CanAttackPlayers(Game game)
        {
            return !game.GetContinuousEffects<CannotAttackPlayersEffect>(this).Any() || game.GetContinuousEffects<IgnoreCannotAttackPlayersEffects>(this).Any();
        }

        public bool CanEvolveFrom(IGame game, ICard card)
        {
            return game.GetContinuousEffects<IEvolutionEffect>(this).Any(x => x.CanEvolveFrom(card));
        }

        internal bool CanBeUsedRegardlessOfManaCost(Game game)
        {
            return !Supertypes.Contains(Common.Supertype.Evolution) || game.CanEvolve(this);
        }

        internal bool CanBePaid(Player player)
        {
            return ManaCost <= player.ManaZone.UntappedCards.Count() && HasCivilizations(player.ManaZone.UntappedCards, Civilizations);
        }

        internal IEnumerable<IEnumerable<Card>> GetManaCombinations(Player player)
        {
            return new Combinations<Card>(player.ManaZone.UntappedCards, ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, Civilizations));//.Select(x => x.Select(y => y.Id)));
        }

        internal static bool HasCivilizations(IEnumerable<Card> manas, IEnumerable<Common.Civilization> civs)
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

        internal void PutOnTopOf(Card bait)
        {
            OnTopOf = bait.Id;
            bait.Underneath = Id;
        }

        internal List<Card> Deconstruct(Game game, List<Card> deconstructred)
        {
            if (Underneath != Guid.Empty)
            {
                deconstructred.AddRange(game.GetCard(Underneath).Deconstruct(game, deconstructred));
                Underneath = Guid.Empty;
                return deconstructred;
            }
            else
            {
                OnTopOf = Guid.Empty;
                return new List<Card> { this };
            }
        }
    }
}
