using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class ThirstForTheHunt : Spell
{
    public ThirstForTheHunt() : base("Thirst for the Hunt", 1,
        Civilization.Nature)
    {
        AddSpellAbilities(
            new YourCreaturesGetPowerAttackerUntilEndOfTurnEffect(
                1000,
                new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffectFactory()));
    }
}