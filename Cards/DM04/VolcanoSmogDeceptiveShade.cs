using CardFilters;
using ContinuousEffects.CostModifying;
using Interfaces;

namespace Cards.DM04;

public sealed class VolcanoSmogDeceptiveShade : Creature
{
    public VolcanoSmogDeceptiveShade() : base(
        "Volcano Smog, Deceptive Shade", 6, 5000, Race.Ghost, Civilization.Darkness)
    {
        AddStaticAbilities(
            new CardsCostMoreEffect(
                new CivilizationCardFilter(Civilization.Light),
                2));
    }
}
