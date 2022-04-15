namespace Cards.Cards.DM10
{
    class BatteryCluster : Creature
    {
        public BatteryCluster() : base("Battery Cluster", 2, 3000, Engine.Subtype.CyberCluster, Common.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
