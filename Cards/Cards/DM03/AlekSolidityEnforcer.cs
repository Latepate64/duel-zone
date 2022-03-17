using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class AlekSolidityEnforcer : Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Subtype.Berserker, Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization.Light));
        }
    }
}
