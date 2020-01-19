using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal class TargetCreatureFilter<TZoneCreature> : CreatureFilter<TZoneCreature> where TZoneCreature : IZoneCreature
    {
        internal TZoneCreature Creature { get; private set; }

        internal TargetCreatureFilter(TZoneCreature creature)
        {
            Creature = creature;
        }

        internal override ReadOnlyCreatureCollection<TZoneCreature> FilteredCreatures => new ReadOnlyCreatureCollection<TZoneCreature>(Creature);
    }
}
