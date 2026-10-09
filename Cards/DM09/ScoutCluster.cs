using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class ScoutCluster : Creature
    {
        public ScoutCluster() : base("Scout Cluster", 3, 4000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
