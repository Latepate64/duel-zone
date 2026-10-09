using Abilities.Static;

namespace Cards.DM04
{
    sealed class HunterCluster : Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, 1000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddAbilities(new BlockerAbility());
        }
    }
}
