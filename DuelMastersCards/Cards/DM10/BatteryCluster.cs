using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM10
{
    public class BatteryCluster : Creature
    {
        public BatteryCluster() : base("Battery Cluster", 2, Civilization.Water, 3000, Subtype.CyberCluster)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
