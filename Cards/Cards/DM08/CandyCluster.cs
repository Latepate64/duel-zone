namespace Cards.Cards.DM08
{
    class CandyCluster : Creature
    {
        public CandyCluster() : base("Candy Cluster", 3, 1000, Engine.Subtype.CyberCluster, Engine.Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
