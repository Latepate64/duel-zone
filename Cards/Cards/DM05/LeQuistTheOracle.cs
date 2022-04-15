namespace Cards.Cards.DM05
{
    class LeQuistTheOracle : Creature
    {
        public LeQuistTheOracle() : base("Le Quist, the Oracle", 2, 1500, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect());
        }
    }
}
