using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class PangaeasSong : Spell
{
    public PangaeasSong() : base("Pangaea's Song", 1, Civilization.Nature)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}