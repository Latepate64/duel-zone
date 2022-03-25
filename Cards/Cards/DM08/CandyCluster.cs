namespace Cards.Cards.DM08
{
    class CandyCluster : Creature
    {
        public CandyCluster() : base("Candy Cluster", 3, 1000, Common.Subtype.CyberCluster, Common.Civilization.Water)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeBlockedAbility());
        }
    }
}
