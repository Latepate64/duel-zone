namespace Cards.Cards.DM09
{
    class MicuteTheOracle : Creature
    {
        public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Engine.Race.Guardian, new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
