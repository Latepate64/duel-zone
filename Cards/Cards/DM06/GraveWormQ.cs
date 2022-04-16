namespace Cards.Cards.DM06
{
    class GraveWormQ : Creature
    {
        public GraveWormQ() : base("Grave Worm Q", 5, 3000, Engine.Race.Survivor, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Engine.Race.Survivor)));
        }
    }
}
