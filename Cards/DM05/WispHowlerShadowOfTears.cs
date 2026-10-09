using Abilities.Static;

namespace Cards.DM05
{
    sealed class WispHowlerShadowOfTears : Creature
    {
        public WispHowlerShadowOfTears() : base("Wisp Howler, Shadow of Tears", 3, 2000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new CivilizationSlayerAbility(Interfaces.Civilization.Nature, Interfaces.Civilization.Light));
        }
    }
}
