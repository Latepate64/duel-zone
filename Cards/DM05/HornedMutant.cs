using CardFilters;
using ContinuousEffects.CostModifying;
using Interfaces;

namespace Cards.DM05;

public sealed class HornedMutant : Creature
{
    public HornedMutant() : base("Horned Mutant", 5, 3000, Race.Hedrian, Civilization.Darkness)
    {
        AddStaticAbilities(
            new CardsCostMoreEffect(
                new CivilizationCardFilter(Civilization.Nature),
                1));
    }
}
