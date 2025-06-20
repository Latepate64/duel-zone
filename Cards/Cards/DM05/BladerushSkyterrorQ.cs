using ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class BladerushSkyterrorQ : Engine.Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, [Engine.Race.Survivor, Engine.Race.ArmoredWyvern], Engine.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new DoubleBreakerEffect())));
        }
    }
}
