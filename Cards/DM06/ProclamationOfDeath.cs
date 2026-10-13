using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class ProclamationOfDeath : Spell
{
    public ProclamationOfDeath() : base("Proclamation of Death", 4,
        Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: false,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCards
            ));
    }
}