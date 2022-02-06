﻿using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : Common.Card, ICopyable<Card>, IAttackable
    {
        // 109.3. An object’s characteristics are name, mana cost, color, color indicator, card type, subtype, supertype, rules text, abilities, power, toughness, loyalty, hand modifier, and life modifier. Objects can have some or all of these characteristics. Any other information about an object isn’t a characteristic.

        public List<Ability> Abilities { get; } = new List<Ability>();

        public Card()
        {
        }

        internal Card(Card card) : base(card)
        {
            Abilities = card.Abilities.Select(x => x.Copy()).ToList();
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
            foreach (var ability in Abilities)
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
            }
            SetRulesText();
        }

        public Common.Card Convert()
        {
            return new Common.Card(this);
        }

        private void SetRulesText()
        {
            RulesText = string.Join(System.Environment.NewLine, Abilities.Select(x => x.ToString()));
        }
    }
}
