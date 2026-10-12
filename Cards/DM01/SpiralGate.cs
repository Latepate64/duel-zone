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
            new BounceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCreatures
        ));
    }
}