using Engine;
using Engine.Abilities;
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
        }

        /// <summary>
        /// Creates a static ability for each continuous effect provided and add the abilities to the card.
        /// </summary>
        /// <param name="effects"></param>
        protected void AddStaticAbilities(params Engine.ContinuousEffects.IContinuousEffect[] effects)
        {
            AddAbilities(effects.Select(x => new StaticAbility(x)).ToArray());
        }

        protected void AddShieldTrigger()
        {
            ShieldTrigger = true;
        }
    }
}
