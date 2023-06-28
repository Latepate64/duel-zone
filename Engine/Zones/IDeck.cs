using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IDeck : IZone, ICopyable<IDeck>
    {
        ICard TopCard { get; }

        void Setup(IEnumerable<ICard> cards, IPlayer owner);
        void Shuffle();
        IEnumerable<ICard> GetTopCards(int amount);
        void PutOnBottom(ICard[] cards);
    }
}