namespace DuelMastersModels.Cards
{
    internal abstract class ShieldZoneCard : Card, IShieldZoneCard
    {
        protected internal ShieldZoneCard(ICard card) : base(card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
        }

        public bool KnownToOwner { get; internal set; } = false;

        public bool KnownToOpponent { get; internal set; } = false;
    }
}
