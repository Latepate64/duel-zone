using TriggeredAbilities;

namespace Cards.DM10
{
    class CoreCrashLizard : Engine.Creature
    {
        public CoreCrashLizard() : base("Core-Crash Lizard", 7, 6000, Engine.Race.MeltWarrior, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect()));
        }
    }
}
