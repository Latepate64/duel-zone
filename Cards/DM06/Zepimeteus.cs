using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM06
{
    sealed class Zepimeteus : Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, 2000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
