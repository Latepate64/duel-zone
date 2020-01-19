using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class CardCollection<TZoneCard> : ReadOnlyCardCollection<TZoneCard> where TZoneCard : IZoneCard
    {
        internal CardCollection() : base(new List<TZoneCard>())
        {
        }

        internal void Add(TZoneCard card)
        {
            Items.Add(card);
        }

        internal void Remove(TZoneCard card)
        {
            Items.Remove(card);
        }
    }
}
