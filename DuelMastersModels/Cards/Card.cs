using DuelMastersModels.Abilities.StaticAbilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public abstract class Card : ICopyable<Card>
    {
        public IEnumerable<Civilization> Civilizations { get; private set; }

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        public int Cost { get; private set; }

        public bool Tapped { get; set; }

        public System.Guid Id { get; set; }

        protected IList<StaticAbility> StaticAbilities { get; private set; } = new List<StaticAbility>();

        protected Card(int cost, IEnumerable<Civilization> civilizations)
        {
            Civilizations = civilizations;
            Cost = cost;
        }

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(int cost, Civilization civilization) : this(cost, new Collection<Civilization> { civilization }) { }

        public abstract Card Copy();

        protected Card Copy(Card card)
        {
            card.Civilizations = new Collection<Civilization>(Civilizations.ToList());
            card.Cost = Cost;
            card.StaticAbilities = StaticAbilities.Select(x => x.Copy()).Cast<StaticAbility>().ToList();
            card.Tapped = Tapped;
            card.Id = Id;
            return card;
        }
    }
}
