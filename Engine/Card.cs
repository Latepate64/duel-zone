using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : Common.Card, ICopyable<Card>, IAttackable, ITimestampable
    {
        private IEnumerable<Ability> Abilities => _printedAbilities.Union(_addedAbilities);
        private readonly List<Ability> _printedAbilities = new();
        private readonly List<Ability> _addedAbilities = new();

        private readonly int? _printedPower;

        public int Timestamp { get; }

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }

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
                        effect.Filter.Target = Id;
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

        internal void ResetToPrintedValues()
        {
            Power = _printedPower;
            _addedAbilities.Clear();
        }
    }
}
