using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class RippleLotusQ : Engine.Creature
    {
        public RippleLotusQ() : base("Ripple Lotus Q", 6, 2000, [Engine.Race.Survivor, Engine.Race.CyberVirus], Engine.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect())));
        }
    }
}
