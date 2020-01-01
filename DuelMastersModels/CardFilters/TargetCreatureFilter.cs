using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal class TargetCreatureFilter : CreatureFilter
    {
        internal Creature Creature { get; private set; }

        internal TargetCreatureFilter(Creature creature)
        {
            Creature = creature;
        }

        internal override ReadOnlyCreatureCollection FilteredCreatures => new ReadOnlyCreatureCollection(Creature);
    }
}
