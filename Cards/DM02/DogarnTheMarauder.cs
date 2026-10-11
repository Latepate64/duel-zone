using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM02;

sealed class DogarnTheMarauder : Creature
{
    public DogarnTheMarauder() : base("Dogarn, the Marauder", 3, 2000,
        Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
                2000, new TappedCreatureFilter()));
    }
}