using CardFilters;
using ContinuousEffects.CostModifying;
using Interfaces;

namespace Cards.DM04;

public sealed class DewMushroom : Creature
{
    public DewMushroom() : base("Dew Mushroom", 3, 1000, Race.BalloonMushroom, Civilization.Nature)
    {
        AddStaticAbilities(
            new CardsCostMoreEffect(
                new CivilizationCardFilter(Civilization.Darkness),
                1));
    }
}
