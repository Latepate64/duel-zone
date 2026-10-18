using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class BurningPower : Spell
{
    public BurningPower(PowerAttackerAbilityFactory powerAttackerAbilityFactory) : base(
        "Burning Power", 1, Civilization.Fire)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
                powerAttackerAbilityFactory.Create(2000),
                new CreatureFilter(),
                new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory()
        ));
    }
}
