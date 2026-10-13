using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class VolcanoCharger : Charger
{
    public VolcanoCharger() : base("Volcano Charger", 4, Civilization.Fire)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(2000),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}