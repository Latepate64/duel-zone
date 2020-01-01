using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public class CardCollection : ReadOnlyCardCollection
    {
        public CardCollection() : base(new List<Card>())
        {
        }

        public void Add(Card card)
        {
            Items.Add(card);
        }

        internal void Remove(Card card)
        {
            Items.Remove(card);
        }

        internal void Shuffle()
        {
            System.Random random = new System.Random(System.Guid.NewGuid().GetHashCode());
            int n = Items.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = Items[k];
                Items[k] = Items[n];
                Items[n] = value;
            }
        }

        #region ReadOnlyCardCollection
        internal ReadOnlyCardCollection TappedCards => new ReadOnlyCardCollection(Items.Where(card => card.Tapped));
        internal ReadOnlyCardCollection UntappedCards => new ReadOnlyCardCollection(Items.Where(card => !card.Tapped));

        
        #endregion ReadOnlyCardCollection

        #region ReadOnlyCreatureCollection
        internal ReadOnlyCreatureCollection Creatures => new ReadOnlyCreatureCollection(Items.Where(card => card is Creature).Cast<Creature>());
        internal ReadOnlyCreatureCollection TappedCreatures => new ReadOnlyCreatureCollection(Creatures.TappedCreatures);
        internal ReadOnlyCreatureCollection UntappedCreatures => new ReadOnlyCreatureCollection(Creatures.Where(creature => !creature.Tapped));
        internal ReadOnlyCreatureCollection NonEvolutionCreatures => new ReadOnlyCreatureCollection(Creatures.Where(c => !(c is EvolutionCreature)));
        internal ReadOnlyCreatureCollection NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone => new ReadOnlyCreatureCollection(NonEvolutionCreatures.Where(c => c.Cost <= Items.Count));
        #endregion ReadOnlyCreatureCollection

        private ReadOnlyCardCollection UntappedCardsWithCivilizations(ReadOnlyCivilizationCollection civilizations)
        {
            return new ReadOnlyCardCollection(UntappedCards.Where(card => card.Civilizations.Intersect(civilizations).Count() > 0));
        }
    }

    /// <summary>
    /// Read-only collection that contains cards.
    /// </summary>
    public class ReadOnlyCardCollection : ReadOnlyCollection<Card>
    {
        /// <summary>
        /// Creates a read-only card collection.
        /// </summary>
        /// <param name="cards">Cards that will be added to the collection.</param>
        public ReadOnlyCardCollection(IEnumerable<Card> cards) : base(cards.ToList()) { }

        internal ReadOnlyCardCollection() : base(new List<Card>())
        { }

        internal ReadOnlyCardCollection(Card card) : base(new List<Card>() { card }) { }
    }

    /// <summary>
    /// Read-only collection that contains creatures.
    /// </summary>
    public class ReadOnlyCreatureCollection : ReadOnlyCollection<Creature>
    {
        internal ReadOnlyCreatureCollection(Creature creature) : base(new List<Creature>() { creature }) { }

        internal ReadOnlyCreatureCollection(IEnumerable<Creature> creatures) : base(creatures.ToList()) { }

        internal ReadOnlyCreatureCollection TappedCreatures => new ReadOnlyCreatureCollection(Items.Where(creature => creature.Tapped));
    }

    internal class ReadOnlySpellCollection : ReadOnlyCollection<Spell>
    {
        internal ReadOnlySpellCollection(IEnumerable<Spell> spells) : base(spells.ToList()) { }

        internal ReadOnlySpellCollection(Spell spell) : base(new List<Spell>() { spell }) { }
    }

    internal class SpellCollection : ReadOnlySpellCollection
    {
        internal SpellCollection() : base(new List<Spell>())
        {
        }

        internal void Add(Spell spell)
        {
            Items.Add(spell);
        }

        internal void Remove(Spell spell)
        {
            Items.Remove(spell);
        }
    }
}
