using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class BatteryCluster : Creature
    {
        public BatteryCluster() : base("Battery Cluster", 2, 3000, Common.Subtype.CyberCluster, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
