namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Represents a battle zone card.
    /// </summary>
    public abstract class BattleZoneCard : Card, IBattleZoneCard
    {
        /// <summary>
        /// Creates a battle zone card.
        /// </summary>
        /// <param name="card"></param>
        protected BattleZoneCard(ICard card) : base(card == null ? throw new System.ArgumentNullException(nameof(card)) : card.Name, card.CardSet, card.Id, card.Cost, card.Text, card.Flavor, card.Illustrator, card.Civilizations, card.Rarity)
        {
        }
    }
}
