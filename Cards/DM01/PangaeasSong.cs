using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class PangaeasSong : Spell
{
    public PangaeasSong() : base("Pangaea's Song", 1, Civilization.Nature)
    {
        AddSpellAbilities(
            new ManaFeedEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}