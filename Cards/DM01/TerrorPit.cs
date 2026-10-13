using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class TerrorPit : Spell
{
    public TerrorPit() : base("Terror Pit", 6, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCards
            ));
    }
}