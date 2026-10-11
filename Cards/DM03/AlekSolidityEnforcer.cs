using Abilities.Static;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM03;

sealed class AlekSolidityEnforcer : Creature
{
    public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000,
        Race.Berserker, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
                1000, new CivilizationCreatureFilter(Civilization.Light)
            ));
    }
}