namespace Cards.Cards.DM06
{
    class RippleLotusQ : Creature
    {
        public RippleLotusQ() : base("Ripple Lotus Q", 6, 2000, Engine.Race.Survivor, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
