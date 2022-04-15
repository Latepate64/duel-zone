namespace Cards.Cards.DM09
{
    class ScoutCluster : Creature
    {
        public ScoutCluster() : base("Scout Cluster", 3, 4000, Engine.Subtype.CyberCluster, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
