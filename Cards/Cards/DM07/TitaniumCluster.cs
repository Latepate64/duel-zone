using Common;

namespace Cards.Cards.DM07
{
    class TitaniumCluster : Creature
    {
        public TitaniumCluster() : base("Titanium Cluster", 4, 4000, Subtype.CyberCluster, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new StaticAbilities.ThisCreatureCannotBeAttackedAbility(), new StaticAbilities.ThisCreatureCannotAttackAbility());
        }
    }
}
