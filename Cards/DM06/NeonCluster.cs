using Engine.Abilities;

namespace Cards.DM06
{
    sealed class NeonCluster : Engine.Creature
    {
        public NeonCluster() : base("Neon Cluster", 7, 4000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.DrawTwoCardsEffect()));
        }
    }
}
