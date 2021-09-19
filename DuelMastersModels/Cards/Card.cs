using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    public abstract class Card
    {
        public IPlayer Owner { get; set; }

        public IEnumerable<Civilization> Civilizations { get; }

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        public int Cost { get; private set; }

        public bool Tapped { get; set; }

        protected Card(int cost, IEnumerable<Civilization> civilizations)
        {
            Civilizations = civilizations;
            Cost = cost;
        }

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(int cost, Civilization civilization) : this(cost, new Collection<Civilization> { civilization }) { }
    }
}
