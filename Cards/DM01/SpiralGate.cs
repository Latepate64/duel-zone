using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class SpiralGate : Spell
{
    public SpiralGate() : base("Spiral Gate", 2, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                1, 1, new CreatureFilter()
            ));
    }
}