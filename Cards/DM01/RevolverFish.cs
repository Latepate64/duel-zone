using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM01
{
    sealed class RevolverFish : Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, 5000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
