using TriggeredAbilities;

namespace Cards.DM04
{
    class KolonTheOracle : Engine.Creature
    {
        public KolonTheOracle() : base("Kolon, the Oracle", 4, 1000, Interfaces.Race.LightBringer, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
