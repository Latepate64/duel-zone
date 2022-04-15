namespace Cards.Cards.DM04
{
    class HunterCluster : Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, 1000, Engine.Subtype.CyberCluster, Common.Civilization.Water)
        {
            AddShieldTrigger();
            AddBlockerAbility();
        }
    }
}
