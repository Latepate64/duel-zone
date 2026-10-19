using CardFilters;
using ContinuousEffects.CannotBeAttacked;
using ContinuousEffects.Unblockable;
using Interfaces;

namespace Cards.DM04;

sealed class PurplePiercer : Creature
{
    public PurplePiercer() : base("Purple Piercer", 3, 2000, Race.BrainJacker, Civilization.Darkness)
    {
        AddStaticAbilities(
            new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Civilization.Light),
            new ThisCreatureCannotBeBlockedEffect(
                new CivilizationCreatureFilter(Civilization.Light)));
    }
}