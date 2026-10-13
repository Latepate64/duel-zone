using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class LightningCharger : Charger
{
    public LightningCharger() : base("Lightning Charger", 4, Civilization.Light)
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