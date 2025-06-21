using TriggeredAbilities;

namespace Cards.DM06
{
    class OverloadCluster : Engine.Creature
    {
        public OverloadCluster() : base("Overload Cluster", 5, 4000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
        }
    }
}
