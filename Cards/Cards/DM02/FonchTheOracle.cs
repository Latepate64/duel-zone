namespace Cards.Cards.DM02
{
    class FonchTheOracle : Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, 2000, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect());
        }
    }
}
