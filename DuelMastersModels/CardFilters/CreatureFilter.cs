using DuelMastersModels.Cards;

namespace DuelMastersModels.CardFilters
{
    internal abstract class CreatureFilter<TZoneCreature> : CardFilter where TZoneCreature : IZoneCreature
    {
        internal abstract ReadOnlyCreatureCollection<TZoneCreature> FilteredCreatures { get; }
    }
}
