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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        protected Spell Copy(Spell spell)
        {
            return base.Copy(spell) as Spell;
        }
    }
}
