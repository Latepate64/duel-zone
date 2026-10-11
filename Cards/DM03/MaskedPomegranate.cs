using CardFilters;
using ContinuousEffects.PowerModifying;
using ContinuousEffects.Unblockable;
using Interfaces;

namespace Cards.DM03;

sealed class MaskedPomegranate : Creature
{
    public MaskedPomegranate() : base("Masked Pomegranate", 5, 1000,
        Race.TreeFolk, Civilization.Nature)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
                1000, new CivilizationCreatureFilter(Civilization.Nature)),
            new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(
                4000));
    }
}