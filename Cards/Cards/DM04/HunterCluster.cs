using Cards.StaticAbilities;

namespace Cards.Cards.DM04
{
    class HunterCluster : Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, 1000, Common.Subtype.CyberCluster, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            AddAbilities(new BlockerAbility());
        }
    }
}
