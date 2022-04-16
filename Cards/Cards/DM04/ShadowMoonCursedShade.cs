using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class ShadowMoonCursedShade : Creature
    {
        public ShadowMoonCursedShade() : base("Shadow Moon, Cursed Shade", 4, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new EachOtherCivilizationCreaturePowerEffect(Engine.Civilization.Darkness, 2000));
        }
    }
}
