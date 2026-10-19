using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class AbductionCharger : Charger
{
    public AbductionCharger() : base("Abduction Charger", 7, Civilization.Water)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.AllCards
        ));
    }
}