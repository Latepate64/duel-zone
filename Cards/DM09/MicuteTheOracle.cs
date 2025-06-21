using TriggeredAbilities;

namespace Cards.DM09
{
    class MicuteTheOracle : Engine.Creature
    {
        public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Interfaces.Race.Guardian, new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
