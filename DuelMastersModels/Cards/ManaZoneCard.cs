namespace DuelMastersModels.Cards
{
    internal class ManaZoneCard : Card, IManaZoneCard
    {
        internal ManaZoneCard(IZoneCard card) : base(card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
        }

        public bool Tapped { get; set; }
    }
}
