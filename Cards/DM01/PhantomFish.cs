using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM01
{
    sealed class PhantomFish : Creature
    {
        public PhantomFish() : base("Phantom Fish", 3, 4000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
