using Common;

namespace Cards.Cards.DM06
{
    class NeonCluster : Creature
    {
        public NeonCluster() : base("Neon Cluster", 7, 4000, Subtype.CyberCluster, Civilization.Water)
        {
            AddTapAbility(new OneShotEffects.DrawCardsEffect(2));
        }
    }
}
