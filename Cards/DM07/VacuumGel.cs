using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class VacuumGel : Spell
{
    public VacuumGel() : base("Vacuum Gel", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MultiFilter(
                    new UntappedCreatureFilter(),
                    new CivilizationCreatureFilter(
                        Civilization.Light, Civilization.Nature)
                ),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}
