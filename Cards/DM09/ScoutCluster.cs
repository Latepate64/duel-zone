using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM09
{
    class ScoutCluster : Engine.Creature
    {
        public ScoutCluster() : base("Scout Cluster", 3, 4000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
