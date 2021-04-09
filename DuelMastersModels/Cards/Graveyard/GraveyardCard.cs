namespace DuelMastersModels.Cards
{
    internal abstract class GraveyardCard : Card, IGraveyardCard
    {
        protected internal GraveyardCard(ICard card) : base(card.Cost, card.Civilizations)
        {
        }
    }
}
