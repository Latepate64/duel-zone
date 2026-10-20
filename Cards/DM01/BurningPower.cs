using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class BurningPower : Spell
{
    public BurningPower(
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        CreaturesGetAbilitiesEffectFactory creaturesGetAbilitiesEffectFactory) : base(
        "Burning Power", 1, Civilization.Fire)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsAbilitiesEffect(
                new CreatureFilter(),
                creaturesGetAbilitiesEffectFactory,
                new UntilEndOfThisTurnDuration(),
                powerAttackerAbilityFactory.Create(2000)
        ));
    }
}
