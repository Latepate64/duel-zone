using ContinuousEffects;

namespace Cards.DM03
{
    class AlekSolidityEnforcer : Engine.Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Light));
        }
    }
}
