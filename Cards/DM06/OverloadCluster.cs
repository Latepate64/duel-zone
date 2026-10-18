using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class OverloadCluster : Creature
{
    public OverloadCluster() : base("Overload Cluster", 5, 4000,
        Race.CyberCluster, Civilization.Water)
    {
        AddTriggeredAbility(
            new OpponentSummonOrCastAbility(
                new ThisCreatureGetsAbilityEffect(
                    new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory(),
                    new BlockerAbility()
        )));
    }
}