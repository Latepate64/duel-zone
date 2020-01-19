namespace DuelMastersModels.Cards
{
    internal class DeckCard : Card, IDeckCard
    {
        internal DeckCard(IZoneCard card) : base(card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
        }

        public bool KnownToOwner { get; internal set; } = true;

        public bool KnownToOpponent { get; internal set; } = false;
    }
}
