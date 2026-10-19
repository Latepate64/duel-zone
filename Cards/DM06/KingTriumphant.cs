using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class KingTriumphant : Creature
{
    public KingTriumphant() : base("King Triumphant", 8, 7000, Race.Leviathan, Civilization.Water)
    {
        AddTriggeredAbility(
            new OpponentSummonOrCastAbility(
                new ThisCreatureGetsAbilityEffect(
                    new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory(),
                    new BlockerAbility()
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}