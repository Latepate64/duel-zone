using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class MegaDetonator : Spell
{
    public MegaDetonator(
        MegaDetonatorDiscardEffectFactory megaDetonatorDiscardEffectFactory,
        MegaDetonatorContinuousEffectFactory megaDetonatorContinuousEffectFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("Mega Detonator", 2, Civilization.Fire)
    {
        AddSpellAbilities(
            megaDetonatorDiscardEffectFactory.Create(
                megaDetonatorContinuousEffectFactory,
                doubleBreakerAbilityFactory.Create()
            ));
    }
}
