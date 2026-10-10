using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

sealed class ClearloGraceEnforcer : Creature
{
    public ClearloGraceEnforcer() : base("Clearlo, Grace Enforcer", 3, 1000,
        Race.Berserker, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
            1000, new UntappedCreatureFilter()));
    }
}