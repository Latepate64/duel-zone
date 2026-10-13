using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class FreezingIcehammer : Spell
{
    public FreezingIcehammer() : base("Freezing Icehammer", 3,
        Civilization.Nature)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CivilizationCreatureFilter(
                    Civilization.Water, Civilization.Darkness),
                source: ZoneType.BattleZone,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OpponentsCards
        ));
    }
}
