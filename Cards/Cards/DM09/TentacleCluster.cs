namespace Cards.Cards.DM09
{
    class TentacleCluster : Engine.Creature
    {
        public TentacleCluster() : base("Tentacle Cluster", 5, 2000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
