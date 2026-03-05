using ContinuousEffects;
using Interfaces;

namespace Cards.DM04;

public sealed class ShadowMoonCursedShade : Creature
{
    public ShadowMoonCursedShade() : base("Shadow Moon, Cursed Shade", 4, 3000, Race.Ghost, Civilization.Darkness)
    {
        AddStaticAbilities(new EachOtherCivilizationCreaturePowerEffect(Civilization.Darkness, 2000));
    }
}
