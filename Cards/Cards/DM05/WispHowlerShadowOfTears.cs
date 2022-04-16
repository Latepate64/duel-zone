using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class WispHowlerShadowOfTears : Creature
    {
        public WispHowlerShadowOfTears() : base("Wisp Howler, Shadow of Tears", 3, 2000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Engine.Civilization.Nature, Engine.Civilization.Light));
        }
    }
}
