using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class MagmaGazer : Spell
{
    public MagmaGazer() : base("Magma Gazer", 3, Civilization.Fire)
    {
        AddSpellAbilities(
            new CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
                4000,
                new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffectFactory()
            ));
    }
}
