using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.CardFilters
{
    internal abstract class CreatureFilter<TCreature> : CardFilter where TCreature : Creature
    {
        internal abstract IEnumerable<TCreature> FilteredCreatures { get; }
    }
}
