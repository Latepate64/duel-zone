using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class FullDefensor : Spell
{
    public FullDefensor() : base("Full Defensor", 2, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new InvincibleUnityOneShotEffect(
                new FullDefensorContinuousEffectFactory(),
                new CreatureFilter()
            ));
    }
}
