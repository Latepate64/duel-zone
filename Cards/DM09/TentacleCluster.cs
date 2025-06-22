using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class TentacleCluster : Engine.Creature
    {
        public TentacleCluster() : base("Tentacle Cluster", 5, 2000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
