using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class MulchCharger : Charger
{
    public MulchCharger() : base("Mulch Charger", 3, Civilization.Nature)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}