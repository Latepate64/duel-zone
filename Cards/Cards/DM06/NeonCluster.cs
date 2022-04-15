namespace Cards.Cards.DM06
{
    class NeonCluster : Creature
    {
        public NeonCluster() : base("Neon Cluster", 7, 4000, Engine.Subtype.CyberCluster, Engine.Civilization.Water)
        {
            AddTapAbility(new OneShotEffects.DrawCardsEffect(2));
        }
    }
}
