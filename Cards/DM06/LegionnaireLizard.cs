using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class LegionnaireLizard : Creature
{
    public LegionnaireLizard() : base("Legionnaire Lizard", 6, 4000,
        Race.DuneGecko, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new OneOfYourCreaturesGetsAbilitiesEffect(
                    new CreatureFilter(),
                    new CreaturesGetAbilitiesEffectFactory(),
                    new UntilEndOfThisTurnDuration(),
                    new SpeedAttackerAbility()
                )));
    }
}