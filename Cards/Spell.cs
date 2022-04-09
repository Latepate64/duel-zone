using Common;
using Engine.Abilities;
using System.Linq;

namespace Cards
{
    abstract class Spell : CardImplementation
    {
        protected Spell(string name, int manaCost, Civilization civilization) : base(CardType.Spell, name, manaCost, null, civilization)
        {
        }

        protected Spell(string name, int manaCost, Civilization civilization1, Civilization civilization2) : base(CardType.Spell, name, manaCost, null, civilization1, civilization2)
        {
        }

        /// <summary>
        /// Adds a spell ability for each one-shot effect provided.
        /// </summary>
        /// <param name="oneShotEffects"></param>
        protected void AddSpellAbilities(params Engine.Abilities.IOneShotEffect[] oneShotEffects)
        {
            AddAbilities(oneShotEffects.Select(x => new Engine.Abilities.SpellAbility(x)).ToArray());
        }
    }

    abstract class Charger : Spell
    {
        protected Charger(string name, int manaCost, Civilization civilization) : base(name, manaCost, civilization)
        {
            AddAbilities(new ChargerAbility());
        }
    }

    class ChargerAbility : StaticAbility
    {
        public ChargerAbility() : base(new ContinuousEffects.ThisSpellHasChargerEffect())
        {
            FunctionZone = ZoneType.Anywhere;
        }
    }
}
