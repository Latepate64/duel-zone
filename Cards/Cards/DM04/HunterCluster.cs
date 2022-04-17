namespace Cards.Cards.DM04
{
    class HunterCluster : Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, 1000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddBlockerAbility();
        }
    }
}
