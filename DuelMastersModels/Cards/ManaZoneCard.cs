namespace DuelMastersModels.Cards
{
    internal class ManaZoneCard : Card, IManaZoneCard
    {
        internal ManaZoneCard(ICard card) : base(card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
            Tapped = Civilizations.Count > 1;
        }

        public bool Tapped { get; set; }
    }
}
