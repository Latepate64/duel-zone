using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM09
{
    class ScoutCluster : Engine.Creature
    {
        public ScoutCluster() : base("Scout Cluster", 3, 4000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
