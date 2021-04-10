using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    public interface IDeck : IZone<IDeckCard>
    {
        void Shuffle();
        ICard RemoveAndGetTopCard();
    }
}