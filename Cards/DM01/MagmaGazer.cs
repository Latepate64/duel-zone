using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM01;

public sealed class MagmaGazer : Spell
{
    public MagmaGazer() : base("Magma Gazer", 3, Civilization.Fire)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsAbilitiesEffect(
                new CreatureFilter(),
                new CreaturesGetAbilitiesEffectFactory(),
                new UntilEndOfThisTurnDuration(),
                new PowerAttackerAbility(4000),
                new DoubleBreakerAbility()
            ));
    }
}
