using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class FonchTheOracle : Engine.Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, 2000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
