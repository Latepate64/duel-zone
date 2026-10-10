using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM05;

sealed class CrowWinger : Creature
{
    public CrowWinger() : base("Crow Winger", 2, 1000, Race.BeastFolk,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new ThisCreatureGetPowerForEachCreatureYourOpponentControls(
                1000, new CivilizationCreatureFilter(
                    Civilization.Water, Civilization.Darkness)));
    }
}