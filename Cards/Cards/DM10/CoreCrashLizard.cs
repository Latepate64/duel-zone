namespace Cards.Cards.DM10
{
    class CoreCrashLizard : Creature
    {
        public CoreCrashLizard() : base("Core-Crash Lizard", 7, 6000, Engine.Subtype.MeltWarrior, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect());
        }
    }
}
