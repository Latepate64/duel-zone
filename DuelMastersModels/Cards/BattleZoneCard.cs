namespace DuelMastersModels.Cards
{
    internal class BattleZoneCard : Card, IBattleZoneCard
    {
        internal BattleZoneCard(IZoneCard card) : base(card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
        }
    }
}
