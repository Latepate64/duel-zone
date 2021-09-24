namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Spell is a card type.
    /// </summary>
    public abstract class Spell : Card
    {
        /// <summary>
        /// Creates a spell.
        /// </summary>
        protected Spell(int cost, Civilization civilization) : base(cost, civilization) { }

        protected Spell(Spell spell) : base(spell) { }
    }
}
