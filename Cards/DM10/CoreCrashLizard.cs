using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class CoreCrashLizard : Engine.Creature
    {
        public CoreCrashLizard() : base("Core-Crash Lizard", 7, 6000, Interfaces.Race.MeltWarrior, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect()));
        }
    }
}
