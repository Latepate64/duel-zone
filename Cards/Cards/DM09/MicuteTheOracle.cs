using Common;

namespace Cards.Cards.DM09
{
    class MicuteTheOracle : Creature
    {
        public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000, Engine.Subtype.LightBringer, Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(Engine.Subtype.Guardian, new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
