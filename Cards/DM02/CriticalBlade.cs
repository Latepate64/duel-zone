using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

sealed class CriticalBlade : Spell
{
    public CriticalBlade() : base("Critical Blade", 2, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new BlockerFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}