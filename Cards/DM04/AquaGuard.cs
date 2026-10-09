using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM04
{
    sealed class AquaGuard : Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
