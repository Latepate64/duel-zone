using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class NeonCluster : Engine.Creature
    {
        public NeonCluster() : base("Neon Cluster", 7, 4000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.DrawTwoCardsEffect()));
        }
    }
}
