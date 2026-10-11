using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class TentacleCluster : Creature
{
    public TentacleCluster() : base("Tentacle Cluster", 5, 2000,
        Race.CyberCluster, Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
                new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                    0, 1, new CreatureFilter()
                )));
    }
}