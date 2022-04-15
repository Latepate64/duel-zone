using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class ShadowMoonCursedShade : Creature
    {
        public ShadowMoonCursedShade() : base("Shadow Moon, Cursed Shade", 4, 3000, Engine.Subtype.Ghost, Civilization.Darkness)
        {
            AddStaticAbilities(new EachOtherCivilizationCreaturePowerEffect(Civilization.Darkness, 2000));
        }
    }
}
