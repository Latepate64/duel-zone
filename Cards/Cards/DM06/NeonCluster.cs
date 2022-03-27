using Common;

namespace Cards.Cards.DM06
{
    class NeonCluster : Creature
    {
        public NeonCluster() : base("Neon Cluster", 7, 4000, Subtype.CyberCluster, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.DrawCardsEffect(2)));
        }
    }
}
