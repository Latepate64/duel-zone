namespace Cards.Cards.DM06
{
    class OverloadCluster : Creature
    {
        public OverloadCluster() : base("Overload Cluster", 5, 4000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
        }
    }
}
