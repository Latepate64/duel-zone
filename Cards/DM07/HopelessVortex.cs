using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class HopelessVortex : Spell
{
    public HopelessVortex() : base("Hopeless Vortex", 5, Civilization.Darkness)
    {
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}