using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    internal interface ISingleCardSelection<TCard> where TCard : class, ICard
    {
        void Validate(TCard card);
        PlayerAction Perform(Duel duel, TCard card);
    }
}