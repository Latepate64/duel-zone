using Common;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    abstract class CardImplementation : Engine.Card
    {
        protected CardImplementation(CardType type, string name, int manaCost, int? power, params Civilization[] civilizations) : base(power)
        {
            CardType = type;
            Civilizations = civilizations.ToList();
            ManaCost = manaCost;
            Name = name;
            Subtypes = new List<Subtype>();
        }

        protected void AddSubtypes(params Subtype[] subtypes)
        {
            Subtypes.AddRange(subtypes);
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
