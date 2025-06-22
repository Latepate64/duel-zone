using TriggeredAbilities;

namespace Cards.DM04
{
    sealed class KolonTheOracle : Engine.Creature
    {
        public KolonTheOracle() : base("Kolon, the Oracle", 4, 1000, Interfaces.Race.LightBringer, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
