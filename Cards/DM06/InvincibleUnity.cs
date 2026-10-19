using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class InvincibleUnity : Spell
{
    public InvincibleUnity() : base("Invincible Unity", 13, Civilization.Nature)
    {
        AddSpellAbilities(
            new AddContinuousEffectWithAbilityIntegerAndCreaturesEffect(
                new CreaturesGetPowerAndAbilityEffectFactory(),
                new CreatureFilter(),
                8000,
                new TripleBreakerAbility(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}
