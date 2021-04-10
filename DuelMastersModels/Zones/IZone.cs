using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Zones
{
    public interface IZone<TCard> where TCard : ICard
    {
        IEnumerable<TCard> Cards { get; }

        ///<summary>
        /// Adds a card to the zone.
        ///</summary>
        void Add(TCard card, IDuel duel);

        ///<summary>
        /// Removes a card from the zone.
        ///</summary>
        void Remove(TCard card, IDuel duel);
    }
}