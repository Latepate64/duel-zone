using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public class ObservableCardCollection : ObservableCollection<Card>
    {
        public ObservableCardCollection() { }

        public ObservableCardCollection(ObservableCardCollection list) : base(list)
        {
        }

        #region ReadOnlyCardCollection
        public ReadOnlyCardCollection TappedCards => new ReadOnlyCardCollection(Items.Where(card => card.Tapped));
        public ReadOnlyCardCollection UntappedCards => new ReadOnlyCardCollection(Items.Where(card => !card.Tapped));

        public ReadOnlyCardCollection UntappedCardsWithCivilizations(ReadOnlyCivilizationCollection civilizations)
        {
            return new ReadOnlyCardCollection(UntappedCards.Where(card => card.Civilizations.Intersect(civilizations).Count() > 0));
        }
        #endregion ReadOnlyCardCollection

        #region ReadOnlyCreatureCollection
        public ReadOnlyCreatureCollection Creatures => new ReadOnlyCreatureCollection(Items.Where(card => card is Creature).Cast<Creature>());
        public ReadOnlyCreatureCollection TappedCreatures => new ReadOnlyCreatureCollection(Creatures.TappedCreatures);
        public ReadOnlyCreatureCollection UntappedCreatures => new ReadOnlyCreatureCollection(Creatures.Where(creature => !creature.Tapped));
        public ReadOnlyCreatureCollection NonEvolutionCreatures => new ReadOnlyCreatureCollection(Creatures.Where(c => !(c is EvolutionCreature)));
        public ReadOnlyCreatureCollection NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone => new ReadOnlyCreatureCollection(NonEvolutionCreatures.Where(c => c.Cost <= Items.Count));
        #endregion ReadOnlyCreatureCollection
    }

    public class CardCollection : ReadOnlyCardCollection
    {
        public CardCollection() : base(new List<Card>())
        {
        }

        public void Add(Card card)
        {
            Items.Add(card);
        }

        public void Remove(Card card)
        {
            Items.Remove(card);
        }
    }

    public class ReadOnlyCardCollection : ReadOnlyCollection<Card>
    {
        public ReadOnlyCardCollection(IEnumerable<Card> cards) : base(cards.ToList()) { }

        public ReadOnlyCardCollection(Card card) : base(new List<Card>() { card }) { }
    }

    public class ReadOnlyCreatureCollection : ReadOnlyCollection<Creature>
    {
        public ReadOnlyCreatureCollection(IEnumerable<Creature> creatures) : base(creatures.ToList()) { }

        public ReadOnlyCreatureCollection(Creature creature) : base(new List<Creature>() { creature }) { }

        public ReadOnlyCreatureCollection TappedCreatures => new ReadOnlyCreatureCollection(Items.Where(creature => creature.Tapped));
    }

    public class ReadOnlySpellCollection : ReadOnlyCollection<Spell>
    {
        public ReadOnlySpellCollection(IEnumerable<Spell> spells) : base(spells.ToList()) { }

        public ReadOnlySpellCollection(Spell spell) : base(new List<Spell>() { spell }) { }
    }

    public class SpellCollection : ReadOnlySpellCollection
    {
        public SpellCollection() : base(new List<Spell>())
        {
        }

        public void Add(Spell spell)
        {
            Items.Add(spell);
        }

        public void Remove(Spell spell)
        {
            Items.Remove(spell);
        }
    }
}
