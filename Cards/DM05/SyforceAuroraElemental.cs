using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM05
{
    sealed class SyforceAuroraElemental : Creature
    {
        public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
