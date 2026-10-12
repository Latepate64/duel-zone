using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class Teleportation : Spell
{
    public Teleportation() : base("Teleportation", 5, Civilization.Water)
    {
        AddSpellAbilities(
            new BounceEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.AllCreatures
        ));
    }
}