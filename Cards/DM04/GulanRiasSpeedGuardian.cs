using CardFilters;
using ContinuousEffects;
using ContinuousEffects.Unblockable;
using Interfaces;

namespace Cards.DM04;

sealed class GulanRiasSpeedGuardian : Creature
{
    public GulanRiasSpeedGuardian() : base("Gulan Rias, Speed Guardian", 3, 2000, Race.Guardian, Civilization.Light)
    {
        AddStaticAbilities(
            new ThisCreatureCannotBeAttackedEffect(
                new CivilizationCreatureFilter(Civilization.Darkness)),
            new ThisCreatureCannotBeBlockedEffect(
                new CivilizationCreatureFilter(Civilization.Darkness)));
    }
}