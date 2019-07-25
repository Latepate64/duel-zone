using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.CardFilters
{
    public abstract class CreatureFilter : CardFilter
    {
        protected CreatureFilter()
        {
        }

        public abstract Collection<Creature> FilteredCreatures { get; }
    }
}
