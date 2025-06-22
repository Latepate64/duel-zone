using ContinuousEffects;

namespace Cards.DM03
{
    sealed class AlekSolidityEnforcer : Engine.Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Interfaces.Race.Berserker, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Light));
        }
    }
}
