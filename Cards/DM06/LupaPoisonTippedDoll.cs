using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class LupaPoisonTippedDoll : Creature
{
    public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000,
        Race.DeathPuppet, Civilization.Darkness)
    {
        AddAbilities(
            new TapAbility(
                new OneOfYourCreaturesGetsAbilityEffect(
                    new SlayerAbility(),
                    new CreatureFilter(),
                    new CreaturesGetAbilitiesEffectFactory(),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}