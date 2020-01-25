using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal abstract class CreatureFilter<TCreature> : CardFilter where TCreature : ICreature
    {
        internal abstract ReadOnlyCreatureCollection<TCreature> FilteredCreatures { get; }
    }
}
