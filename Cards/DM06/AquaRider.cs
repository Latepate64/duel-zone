using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class AquaRider : Creature
{
    public AquaRider() : base("Aqua Rider", 4, 2000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new OpponentSummonOrCastAbility(
                new ThisCreatureGetsAbilityEffect(
                    new CreaturesGetAbilitiesEffectFactory(),
                    new BlockerAbility(),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}