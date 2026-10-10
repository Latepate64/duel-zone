using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

sealed class SiegeRollerBagash : Creature
{
    public SiegeRollerBagash() : base("Siege Roller Bagash", 4, 3000,
        Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
                1000, new TappedCreatureFilter()));
    }
}