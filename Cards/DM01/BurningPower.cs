using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class BurningPower : Spell
{
    public BurningPower() : base("Burning Power", 1, Civilization.Fire)
    {
        AddSpellAbilities(
            new CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
                2000,
                new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffectFactory()
            ));
    }
}
