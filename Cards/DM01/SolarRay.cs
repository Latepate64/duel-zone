using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class SolarRay : Spell
{
    public SolarRay() : base("Solar Ray", 2, Civilization.Light)
    {
        AddShieldTrigger();
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