using Abilities.Static;

namespace Cards.DM05
{
    sealed class BladerushSkyterrorQ : Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, [Interfaces.Race.Survivor, Interfaces.Race.ArmoredWyvern], Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new DoubleBreakerAbility()));
        }
    }
}
