using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.CardFilters
{
    internal class TargetCreatureFilter<TCreature> : CreatureFilter<TCreature> where TCreature : Creature
    {
        internal TCreature Creature { get; private set; }

        internal TargetCreatureFilter(TCreature creature)
        {
            Creature = creature;
        }

        internal override IEnumerable<TCreature> FilteredCreatures => new ReadOnlyCollection<TCreature>(new List<TCreature>() { Creature });
    }
}
