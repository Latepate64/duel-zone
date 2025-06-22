using ContinuousEffects;

namespace Cards.DM05
{
    sealed class WispHowlerShadowOfTears : Engine.Creature
    {
        public WispHowlerShadowOfTears() : base("Wisp Howler, Shadow of Tears", 3, 2000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Interfaces.Civilization.Nature, Interfaces.Civilization.Light));
        }
    }
}
