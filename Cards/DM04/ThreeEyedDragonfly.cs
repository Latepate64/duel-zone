using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using StaticAbilities;

namespace Cards.DM04;

public sealed class ThreeEyedDragonfly : Creature
{
    public ThreeEyedDragonfly() : base("Three-Eyed Dragonfly", 5, 4000,
        Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(
                    new CreatureFilter(),
                    new ThisCreatureGetsPowerAndAbilityEffect(
                        2000,
                        new DoubleBreakerAbility()
                    ),
                    new UntilEndOfThisTurnDuration())));
    }
}
