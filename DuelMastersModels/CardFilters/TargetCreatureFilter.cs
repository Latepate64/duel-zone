using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal class TargetCreatureFilter<TCreature> : CreatureFilter<TCreature> where TCreature : ICreature
    {
        internal TCreature Creature { get; private set; }

        internal TargetCreatureFilter(TCreature creature)
        {
            Creature = creature;
        }

        internal override ReadOnlyCreatureCollection<TCreature> FilteredCreatures => new ReadOnlyCreatureCollection<TCreature>(Creature);
    }
}
