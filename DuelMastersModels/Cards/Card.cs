using DuelMastersModels.Abilities.StaticAbilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public abstract class Card : DuelObject, ICopyable<Card>
    {
        public IEnumerable<Civilization> Civilizations { get; private set; }

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        public int Cost { get; private set; }

        public bool Tapped { get; set; }

        protected IList<StaticAbility> StaticAbilities { get; private set; } = new List<StaticAbility>();

        protected Card(int cost, IEnumerable<Civilization> civilizations)
        {
            Id = System.Guid.NewGuid();
            Civilizations = civilizations;
            Cost = cost;
        }

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(int cost, Civilization civilization) : this(cost, new Collection<Civilization> { civilization }) { }

        protected Card(Card card)
        {
            Civilizations = new Collection<Civilization>(card.Civilizations.ToList());
            Cost = card.Cost;
            StaticAbilities = card.StaticAbilities.Select(x => x.Copy()).Cast<StaticAbility>().ToList();
            Tapped = card.Tapped;
            Id = card.Id;
        }

        public abstract Card Copy();

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
