using CardFilters;
using ContinuousEffects.CannotBeAttacked;
using ContinuousEffects.Unblockable;
using Interfaces;

namespace Cards.DM04;

sealed class GulanRiasSpeedGuardian : Creature
{
    public GulanRiasSpeedGuardian() : base("Gulan Rias, Speed Guardian", 3, 2000, Race.Guardian, Civilization.Light)
    {
        AddStaticAbilities(
            new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Civilization.Darkness),
            new ThisCreatureCannotBeBlockedEffect(
                new CivilizationCreatureFilter(Civilization.Darkness)));
    }
}