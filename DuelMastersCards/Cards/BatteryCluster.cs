using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
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
