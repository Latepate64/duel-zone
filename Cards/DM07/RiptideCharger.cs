using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class RiptideCharger : Charger
{
    public RiptideCharger() : base("Riptide Charger", 5, Civilization.Water)
    {
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