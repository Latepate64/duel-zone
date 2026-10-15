using OneShotEffects;
using Interfaces;
using ContinuousEffects.AbilityAddingPowerModifying;

namespace Cards.DM02;

public sealed class RumbleGate : Spell
{
    public RumbleGate() : base("Rumble Gate", 4, Civilization.Fire)
    {
        AddSpellAbilities(
            new CreatureIntegerAffectingContinuousEffectAddingEffect(
                1000,
                new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory()),
            new RumbleGateOneShotEffect());
    }
}
