using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class SpiralGate : Spell
{
    public SpiralGate() : base("Spiral Gate", 2, Civilization.Water)
    {
        AddShieldTrigger();
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