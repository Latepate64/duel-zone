using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.CardFilters
{
    public abstract class SpellFilter : CardFilter
    {
        protected SpellFilter()
        {
        }

        public abstract Collection<Spell> FilteredSpells { get; }
    }
}
