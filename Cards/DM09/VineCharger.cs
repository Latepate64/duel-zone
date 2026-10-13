using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class VineCharger : Charger
{
    public VineCharger() : base("Vine Charger", 4, Civilization.Nature)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: false,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}