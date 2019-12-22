using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    public class TargetCreatureFilter : CreatureFilter
    {
        public Creature Creature { get; private set; }

        public TargetCreatureFilter(Creature creature)
        {
            Creature = creature;
        }

        public override ReadOnlyCreatureCollection FilteredCreatures => new ReadOnlyCreatureCollection(Creature);
    }
}
