using TriggeredAbilities;

namespace Cards.DM09
{
    class MicuteTheOracle : Engine.Creature
    {
        public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Engine.Race.Guardian, new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
