using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM09
{
    class ScoutCluster : Engine.Creature
    {
        public ScoutCluster() : base("Scout Cluster", 3, 4000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
