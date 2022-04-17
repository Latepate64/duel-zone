namespace Cards.Cards.DM12
{
    class MizoyTheOracle : Creature
    {
        public MizoyTheOracle() : base("Mizoy, the Oracle", 3, 2500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect());
        }
    }
}
