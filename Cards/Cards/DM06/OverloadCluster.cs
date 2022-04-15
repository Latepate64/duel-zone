using Common;

namespace Cards.Cards.DM06
{
    class OverloadCluster : Creature
    {
        public OverloadCluster() : base("Overload Cluster", 5, 4000, Engine.Subtype.CyberCluster, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
        }
    }
}
