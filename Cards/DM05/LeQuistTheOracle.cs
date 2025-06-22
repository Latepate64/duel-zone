using TriggeredAbilities;

namespace Cards.DM05
{
    sealed class LeQuistTheOracle : Engine.Creature
    {
        public LeQuistTheOracle() : base("Le Quist, the Oracle", 2, 1500, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
