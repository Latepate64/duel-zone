namespace DuelMastersModels.Cards
{
    internal class DeckSpell : DeckCard, ISpell
    {
        internal DeckSpell(ICard card) : base(card)
        {
        }
    }
}
