using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal abstract class CreatureFilter : CardFilter
    {
        internal abstract ReadOnlyCreatureCollection FilteredCreatures { get; }
    }
}
