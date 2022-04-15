namespace Cards.Cards.DM09
{
    class MicuteTheOracle : Creature
    {
        public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(Engine.Subtype.Guardian, new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
