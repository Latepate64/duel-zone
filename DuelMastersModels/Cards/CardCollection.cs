using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class CardCollection<TCard> : ReadOnlyCardCollection<TCard> where TCard : ICard
    {
        internal CardCollection() : base(new List<TCard>())
        {
        }

        internal void Add(TCard card)
        {
            Items.Add(card);
        }

        internal void Remove(TCard card)
        {
            Items.Remove(card);
        }
    }
}
