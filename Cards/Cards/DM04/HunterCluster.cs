using Cards.StaticAbilities;

namespace Cards.Cards.DM04
{
    public class HunterCluster : Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, Common.Civilization.Water, 1000, Common.Subtype.CyberCluster)
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
        }
    }
}
