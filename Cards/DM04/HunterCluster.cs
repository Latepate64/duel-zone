using ContinuousEffects;

namespace Cards.DM04
{
    sealed class HunterCluster : Engine.Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, 1000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
