using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class VirtualTripwire : Spell
{
    public VirtualTripwire() : base("Virtual Tripwire", 3, Civilization.Water)
    {
        AddSpellAbilities(
            new TapChoiceEffect(
                minimum: 1,
                maximum: 1,
                ownerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OpponentsCards
            ));
    }
}