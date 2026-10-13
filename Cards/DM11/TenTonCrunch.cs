using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

sealed class TenTonCrunch : Spell
{
    public TenTonCrunch() : base("Ten-Ton Crunch", 4, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(3000),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCards
            ));
    }
}