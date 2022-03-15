using Common;

namespace Cards.Cards.DM03
{
    class AlekSolidityEnforcer : Creature
    {
        public AlekSolidityEnforcer() : base("Alek, Solidity Enforcer", 7, 4000, Subtype.Berserker, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new Engine.Abilities.StaticAbility(new ContinuousEffects.PowerModifyingMultiplierEffect(1000, new CardFilters.OwnersBattleZoneCivilizationCreatureExceptFilter(Civilization.Light))));
        }
    }
}
