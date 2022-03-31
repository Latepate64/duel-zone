using Common;

namespace Cards.Cards.DM09
{
    class MicuteTheOracle : Creature
    {
        public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000, Subtype.LightBringer, Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(Subtype.Guardian, new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
