using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class WispHowlerShadowOfTears : Creature
    {
        public WispHowlerShadowOfTears() : base("Wisp Howler, Shadow of Tears", 3, 2000, Subtype.Ghost, Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Civilization.Nature, Civilization.Light));
        }
    }
}
