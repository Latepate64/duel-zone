using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class AlekSolidityEnforcer : Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Subtype.Berserker, Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Civilization.Light));
        }
    }
}
