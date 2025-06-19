namespace Cards.Cards.DM12
{
    class GandavalsStapler : Engine.Creature
    {
        public GandavalsStapler() : base("Gandaval's Stapler", 2, 3000, Engine.Race.Xenoparts, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
