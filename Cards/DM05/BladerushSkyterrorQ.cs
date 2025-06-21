using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    class BladerushSkyterrorQ : Engine.Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, [Interfaces.Race.Survivor, Interfaces.Race.ArmoredWyvern], Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new DoubleBreakerEffect())));
        }
    }
}
