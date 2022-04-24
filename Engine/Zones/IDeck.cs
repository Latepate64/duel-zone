using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IDeck : IZone
    {
        void Setup(IEnumerable<ICard> cards, IPlayer owner);
        void Shuffle();
        IEnumerable<ICard> GetTopCards(int amount);
        void PutOnBottom(ICard[] cards);
    }
}