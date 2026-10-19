using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class FullDefensor : Spell
{
    public FullDefensor(
        CreatureFilterFactory filterFactory,
        BlockerAbilityFactory abilityFactory
        ) : base("Full Defensor", 2, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new AddAbilityAddingEffect(
                new ContinuousEffectWithAbilityFactory(),
                filterFactory.Create(),
                abilityFactory
            ));
    }
}
