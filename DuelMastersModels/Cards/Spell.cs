using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Spell is a card type.
    /// </summary>
    public class Spell : Card
    {
        /// <summary>
        /// Creates a spell.
        /// </summary>
        public Spell(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator)
        {
        }
    }
}
