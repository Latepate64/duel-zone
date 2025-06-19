using Abilities.Triggered;

namespace Cards.Cards.DM05
{
    class LeQuistTheOracle : Engine.Creature
    {
        public LeQuistTheOracle() : base("Le Quist, the Oracle", 2, 1500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
