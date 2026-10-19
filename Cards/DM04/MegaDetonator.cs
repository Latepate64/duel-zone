using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class MegaDetonator : Spell
{
    public MegaDetonator(
        MegaDetonatorDiscardEffectFactory oneShotEffectFactory,
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory continuousEffectFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("Mega Detonator", 2, Civilization.Fire)
    {
        AddSpellAbilities(
            oneShotEffectFactory.Create(
                continuousEffectFactory,
                doubleBreakerAbilityFactory.Create()
            ));
    }
}
