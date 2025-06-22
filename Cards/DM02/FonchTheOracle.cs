using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class FonchTheOracle : Engine.Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, 2000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
