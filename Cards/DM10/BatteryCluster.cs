using ContinuousEffects;

namespace Cards.DM10
{
    class BatteryCluster : Engine.Creature
    {
        public BatteryCluster() : base("Battery Cluster", 2, 3000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
