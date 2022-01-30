using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM04
{
    public class HunterCluster : Creature
    {
        public HunterCluster() : base("Hunter Cluster", 4, Civilization.Water, 1000, Subtype.CyberCluster)
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
        }
    }
}
