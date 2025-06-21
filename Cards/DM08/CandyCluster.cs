using ContinuousEffects;

namespace Cards.DM08
{
    class CandyCluster : Engine.Creature
    {
        public CandyCluster() : base("Candy Cluster", 3, 1000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
