namespace Cards.Cards.DM05
{
    class LeQuistTheOracle : Creature
    {
        public LeQuistTheOracle() : base("Le Quist, the Oracle", 2, 1500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect());
        }
    }
}
