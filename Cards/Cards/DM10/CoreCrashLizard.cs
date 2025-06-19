using Cards.TriggeredAbilities;

namespace Cards.Cards.DM10
{
    class CoreCrashLizard : Creature
    {
        public CoreCrashLizard() : base("Core-Crash Lizard", 7, 6000, Engine.Race.MeltWarrior, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect()));
        }
    }
}
