namespace DuelMastersModels.Cards
{
    internal class HandSpell : HandCard, IHandSpell
    {
        public HandSpell(ICard card) : base(card)
        {
        }
    }
}
