using Common;

namespace Cards.Cards.DM07
{
    class TitaniumCluster : Creature
    {
        public TitaniumCluster() : base("Titanium Cluster", 4, 4000, Subtype.CyberCluster, Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotBeAttackedAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
