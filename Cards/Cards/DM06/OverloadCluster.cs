using Common;

namespace Cards.Cards.DM06
{
    class OverloadCluster : Creature
    {
        public OverloadCluster() : base("Overload Cluster", 5, 4000, Subtype.CyberCluster, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect()));
        }
    }
}
