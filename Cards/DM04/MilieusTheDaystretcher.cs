using StaticAbilities;
using ContinuousEffects.CostModifying;
using Interfaces;
using CardFilters;

namespace Cards.DM04;

public sealed class MilieusTheDaystretcher : Creature
{
    public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Race.Berserker, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(
            new CardsCostMoreEffect(
                new CivilizationCardFilter(Civilization.Darkness),
                2));
    }
}
