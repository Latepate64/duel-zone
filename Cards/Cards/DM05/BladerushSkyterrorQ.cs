using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class BladerushSkyterrorQ : Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, Engine.Race.Survivor, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddSurvivorAbility(new DoubleBreakerEffect());
        }
    }
}
