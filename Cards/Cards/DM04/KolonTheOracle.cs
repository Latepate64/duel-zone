using Abilities.Triggered;

namespace Cards.Cards.DM04
{
    class KolonTheOracle : Engine.Creature
    {
        public KolonTheOracle() : base("Kolon, the Oracle", 4, 1000, Engine.Race.LightBringer, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
