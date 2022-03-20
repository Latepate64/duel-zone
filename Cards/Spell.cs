using Common;
using System.Linq;

namespace Cards
{
    abstract class Spell : CardImplementation
    {
        protected Spell(string name, int manaCost, params Civilization[] civilizations) : base(CardType.Spell, name, manaCost, null, civilizations)
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
        protected Charger(string name, int manaCost, params Civilization[] civilizations) : base(name, manaCost, civilizations)
        {
            AddAbilities(new StaticAbilities.ChargerAbility());
        }
    }
}
