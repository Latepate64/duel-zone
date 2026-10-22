using CardFilters;
using ContinuousEffects;
using ContinuousEffects.Unblockable;
using Interfaces;

namespace Cards.DM04;

sealed class PurplePiercer : Creature
{
    public PurplePiercer() : base("Purple Piercer", 3, 2000, Race.BrainJacker, Civilization.Darkness)
    {
        AddStaticAbilities(
            new ThisCreatureCannotBeAttackedEffect(
                new CivilizationCreatureFilter(Civilization.Light)),
            new ThisCreatureCannotBeBlockedEffect(
                new CivilizationCreatureFilter(Civilization.Light)));
    }
}