using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class BatteryCluster : Creature
    {
        public BatteryCluster() : base("Battery Cluster", 2, Common.Civilization.Water, 3000, Common.Subtype.CyberCluster)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
