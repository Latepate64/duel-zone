using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM03
{
    sealed class AlekSolidityEnforcer : Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Interfaces.Race.Berserker, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Light));
        }
    }
}
