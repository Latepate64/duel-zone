namespace DuelMastersModels.Zones
{
    internal interface ITappableZone//<TTappable> where TTappable : ITappable
    {
        void UntapCards();
        /*
        ReadOnlyCardCollection<IZoneCard> TappedCards { get; }
        ReadOnlyCardCollection<IZoneCard> UntappedCards { get; }

        ReadOnlyCreatureCollection<IZoneCreature> TappedCreatures { get; }
        ReadOnlyCreatureCollection<IZoneCreature> UntappedCreatures { get; }*/
    }
}
