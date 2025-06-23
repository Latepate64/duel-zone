using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    sealed class BlazosaurQ : Creature
    {
        public BlazosaurQ() : base("Blazosaur Q", 2, 1000, [Interfaces.Race.Survivor, Interfaces.Race.RockBeast], Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new PowerAttackerEffect(1000))));
        }
    }
}
