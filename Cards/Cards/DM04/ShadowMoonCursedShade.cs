using Common;

namespace Cards.Cards.DM04
{
    class ShadowMoonCursedShade : Creature
    {
        public ShadowMoonCursedShade() : base("Shadow Moon, Cursed Shade", 4, 3000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.EachOtherCivilizationCreaturePowerAbility(Civilization.Darkness, 2000));
        }
    }
}
