using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

sealed class SolarTrap : Spell
{
    public SolarTrap() : base("Solar Trap", 1, Civilization.Light)
    {
        AddSpellAbilities(
            new TapChoiceEffect(
                minimum: 1,
                maximum: 1,
                ownerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}