using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class AbductionCharger : Charger
{
    public AbductionCharger() : base("Abduction Charger", 7, Civilization.Water)
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