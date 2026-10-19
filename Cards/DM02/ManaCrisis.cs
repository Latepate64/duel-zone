using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

sealed class ManaCrisis : Spell
{
    public ManaCrisis() : base("Mana Crisis", 4, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ManaZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCards
        ));
    }
}