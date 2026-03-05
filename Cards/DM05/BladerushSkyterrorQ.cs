using ContinuousEffects;
using Abilities;

namespace Cards.DM05
{
    sealed class BladerushSkyterrorQ : Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, [Interfaces.Race.Survivor, Interfaces.Race.ArmoredWyvern], Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new DoubleBreakerEffect())));
        }
    }
}
