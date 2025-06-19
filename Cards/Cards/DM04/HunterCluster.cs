using Effects.Continuous;

namespace Cards.Cards.DM04
{
    class HunterCluster : Engine.Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, 1000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
