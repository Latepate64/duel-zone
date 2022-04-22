using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards
{
    class Spell : CardImplementation
    {
        public Spell(ICard card) : base(card)
        {
        }

        protected Spell(string name, int manaCost, Civilization civilization) : base(CardType.Spell, name, manaCost, null, civilization)
        {
        }

        protected Spell(string name, int manaCost, Civilization civilization1, Civilization civilization2) : base(CardType.Spell, name, manaCost, null, civilization1, civilization2)
        {
        }

        public override ICard Copy()
        {
            return new Spell(this);
        }

        /// <summary>
        /// Adds a spell ability for each one-shot effect provided.
        /// </summary>
        /// <param name="oneShotEffects"></param>
        protected void AddSpellAbilities(params IOneShotEffect[] oneShotEffects)
        {
            AddAbilities(oneShotEffects.Select(x => new SpellAbility(x)).ToArray());
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
            FunctionZone = ZoneType.SpellStack;
        }
    }
}
