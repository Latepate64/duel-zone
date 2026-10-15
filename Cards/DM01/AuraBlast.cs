using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class AuraBlast : Spell
{
    public AuraBlast() : base("Aura Blast", 4, Civilization.Nature)
    {
        AddSpellAbilities(
            new CreatureIntegerAffectingContinuousEffectAddingEffect(
                2000,
                new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffectFactory()));
    }
}