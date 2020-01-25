using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Read-only collection that contains cards.
    /// </summary>
    public class ReadOnlyCardCollection<TCard> : ReadOnlyCollection<TCard> where TCard : ICard
    {
        /// <summary>
        /// Creates a read-only card collection.
        /// </summary>
        /// <param name="cards">Cards that will be added to the collection.</param>
        public ReadOnlyCardCollection(IEnumerable<TCard> cards) : base(cards.ToList()) { }

        internal ReadOnlyCardCollection() : base(new List<TCard>())
        { }

        internal ReadOnlyCardCollection(TCard card) : base(new List<TCard>() { card }) { }

        #region ReadOnlyCardCollection
        internal ReadOnlyCardCollection<TCard> TappedCards => new ReadOnlyCardCollection<TCard>(Items.Where(card => card is ITappable tappable && tappable.Tapped));
        internal ReadOnlyCardCollection<TCard> UntappedCards => new ReadOnlyCardCollection<TCard>(Items.Where(card => card is ITappable tappable && !tappable.Tapped));
        #endregion ReadOnlyCardCollection

        #region ReadOnlyCreatureCollection
        internal ReadOnlyCreatureCollection<ICreature> Creatures => new ReadOnlyCreatureCollection<ICreature>(Items.OfType<ICreature>());
        //internal ReadOnlyCreatureCollection<IZoneCreature> TappedCreatures => new ReadOnlyCreatureCollection<IZoneCreature>(Creatures.TappedCreatures);
        //internal ReadOnlyCreatureCollection<IZoneCreature> UntappedCreatures => new ReadOnlyCreatureCollection<IZoneCreature>(Creatures.Where(creature => !creature.Tapped));
        internal ReadOnlyCreatureCollection<ICreature> NonEvolutionCreatures => new ReadOnlyCreatureCollection<ICreature>(Creatures.Where(c => !(c is EvolutionCreature)));
        #endregion ReadOnlyCreatureCollection
    }
}
