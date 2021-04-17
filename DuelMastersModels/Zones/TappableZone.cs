using DuelMastersModels.Cards;
using System.Linq;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Zones
{
    internal abstract class TappableZone<TZoneCard> : Zone<TZoneCard> /*ITappableZone<TZoneCard>*/ where TZoneCard : ITappable, IZoneCard
    {
        internal abstract void UntapCards();

        internal ReadOnlyCollection<TZoneCard> TappedCards => new ReadOnlyCollection<TZoneCard>(Cards.Where(card => card.Tapped).ToList());
        internal ReadOnlyCollection<TZoneCard> UntappedCards => new ReadOnlyCollection<TZoneCard>(Cards.Where(card => !card.Tapped).ToList());
    }
}
