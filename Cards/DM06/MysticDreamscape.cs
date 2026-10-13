using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class MysticDreamscape : Spell
{
    public MysticDreamscape() : base("Mystic Dreamscape", 4, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 3,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ManaZone,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}