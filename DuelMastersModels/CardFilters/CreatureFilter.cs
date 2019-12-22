using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    public abstract class CreatureFilter : CardFilter
    {
        protected CreatureFilter()
        {
        }

        public abstract ReadOnlyCreatureCollection FilteredCreatures { get; }
    }
}
