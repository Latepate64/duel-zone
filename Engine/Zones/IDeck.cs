using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    public interface IDeck : IZone, ICopyable<IDeck>
    {
        ICard TopCard => GetTopCards(1).SingleOrDefault();

        void Setup(IEnumerable<ICard> cards, IPlayer owner);
        void Shuffle();
        IEnumerable<ICard> GetTopCards(int amount);
        void PutOnBottom(ICard[] cards);
    }
}