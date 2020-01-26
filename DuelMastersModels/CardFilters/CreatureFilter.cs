using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.CardFilters
{
    internal abstract class CreatureFilter<TCreature> : CardFilter where TCreature : ICreature
    {
        internal abstract IEnumerable<TCreature> FilteredCreatures { get; }
    }
}
