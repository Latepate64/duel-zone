using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class RiptideCharger : Charger
{
    public RiptideCharger() : base("Riptide Charger", 5, Civilization.Water)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.AllCards
        ));
    }
}