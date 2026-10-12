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
                new BounceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCreatures
        )));
    }
}