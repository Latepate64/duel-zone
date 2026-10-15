using ContinuousEffects.AbilityAddingPowerModifying;
using ContinuousEffects.CannotUseCard;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class BlazeCannon : Spell
{
    public BlazeCannon() : base("Blaze Cannon", 7, Civilization.Fire)
    {
        AddStaticAbilities(new BlazeCannonRestrictionEffect());
        AddSpellAbilities(
            new CreatureIntegerAffectingContinuousEffectAddingEffect(
                4000,
                new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffectFactory()));
    }
}
