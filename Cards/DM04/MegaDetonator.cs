using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class MegaDetonator : Spell
{
    public MegaDetonator(ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory factory) : base(
        "Mega Detonator", 2, Civilization.Fire)
    {
        AddSpellAbilities(
            new DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(
                factory,
                new DoubleBreakerAbility(),
                new UntilEndOfThisTurnDuration()));
    }
}
