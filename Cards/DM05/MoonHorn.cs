using Abilities.Static;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM05;

sealed class MoonHorn : Creature
{
    public MoonHorn() : base("Moon Horn", 6, 6000, Race.HornedBeast,
        Civilization.Nature)
    {
        AddStaticAbilities(
        new ThisCreatureGetPowerForEachCreatureYourOpponentControls(
            1000, new CivilizationCreatureFilter(
                Civilization.Water, Civilization.Darkness)));
        AddAbilities(new DoubleBreakerAbility());
    }
}