using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class AlekSolidityEnforcer : Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Engine.Subtype.Berserker, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Light));
        }
    }
}
