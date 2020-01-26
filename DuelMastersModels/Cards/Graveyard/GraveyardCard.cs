namespace DuelMastersModels.Cards
{
    internal abstract class GraveyardCard : Card, IGraveyardCard
    {
        protected internal GraveyardCard(ICard card) : base(card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
        }
    }
}
