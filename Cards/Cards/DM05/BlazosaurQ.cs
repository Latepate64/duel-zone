using Cards.ContinuousEffects;
using ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class BlazosaurQ : Engine.Creature
    {
        public BlazosaurQ() : base("Blazosaur Q", 2, 1000, [Engine.Race.Survivor, Engine.Race.RockBeast], Engine.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new PowerAttackerEffect(1000))));
        }
    }
}
