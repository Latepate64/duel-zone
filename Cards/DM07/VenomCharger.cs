using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class VenomCharger : Charger
{
    public VenomCharger() : base("Venom Charger", 3, Civilization.Darkness)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsAbilityEffect(
                new SlayerAbility(),
                new CreatureFilter(),
                new CreaturesGetAbilityEffectFactory(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}