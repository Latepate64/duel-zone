using Abilities.Triggered;

namespace Cards.Cards.DM09
{
    class TentacleCluster : Engine.Creature
    {
        public TentacleCluster() : base("Tentacle Cluster", 5, 2000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
