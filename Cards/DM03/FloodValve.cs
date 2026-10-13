using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class FloodValve : Spell
{
    public FloodValve() : base("Flood Valve", 2, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ManaZone,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}