using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class VolcanicArrows : Spell
{
    public VolcanicArrows() : base("Volcanic Arrows", 2, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(6000),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.AllCreatures
            ),
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ShieldZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}