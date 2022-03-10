using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : Common.Card, ICopyable<Card>, IAttackable
    {
        // 109.3. An object’s characteristics are name, mana cost, color, color indicator, card type, subtype, supertype, rules text, abilities, power, toughness, loyalty, hand modifier, and life modifier. Objects can have some or all of these characteristics. Any other information about an object isn’t a characteristic.

        private List<Ability> _abilities = new();

        public IEnumerable<T> GetAbilities<T>()
        {
            return _abilities.OfType<T>();
        }

        public Card()
        {
        }

        internal Card(Card card) : base(card, false)
        {
            _abilities = card._abilities.Select(x => x.Copy()).ToList();
            InitializeAbilities();
        }

        public virtual Card Copy()
        {
            return new Card(this);
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
            foreach (var ability in _abilities)
            {
                ability.Owner = Owner;
                ability.Source = Id;
                if (ability is StaticAbility staticAbility)
                {
                    foreach (var effect in staticAbility.ContinuousEffects)
                    {
                        effect.Filter.Target = Id;
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
            RulesText = string.Join("\r\n", _abilities.Select(x => x.ToString()));
        }

        internal void AddAbility(Ability ability)
        {
            _abilities.Add(ability);
        }

        internal void RemoveAbility(System.Guid id)
        {
            _ = _abilities.RemoveAll(x => x.Id == id);
        }

        protected void AddAbilities(params Ability[] abilities)
        {
            _abilities.AddRange(abilities);
        }

        public bool IsEvolutionCreature => Supertypes.Any(x => x == Common.Supertype.Evolution);
    }
}
