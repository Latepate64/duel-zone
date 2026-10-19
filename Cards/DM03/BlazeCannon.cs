using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.CannotUseCard;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class BlazeCannon : Spell
{
    public BlazeCannon(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory effectFactory
    ) : base("Blaze Cannon", 7, Civilization.Fire)
    {
        AddStaticAbilities(new BlazeCannonRestrictionEffect());
        AddSpellAbilities(
            effectFactory.Create(
                new CreatureFilter(),
                new ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory(),
                new UntilEndOfThisTurnDuration(),
                new PowerAttackerAbility(4000),
                new DoubleBreakerAbility()));
    }
}
