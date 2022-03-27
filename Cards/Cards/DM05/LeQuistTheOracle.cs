using Common;

namespace Cards.Cards.DM05
{
    class LeQuistTheOracle : Creature
    {
        public LeQuistTheOracle() : base("Le Quist, the Oracle", 2, 1500, Subtype.LightBringer, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
