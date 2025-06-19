using Cards.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class CandyCluster : Engine.Creature
    {
        public CandyCluster() : base("Candy Cluster", 3, 1000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
