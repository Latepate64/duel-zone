using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Read-only collection that contains cards.
    /// </summary>
    public class ReadOnlyCardCollection<TZoneCard> : ReadOnlyCollection<TZoneCard> where TZoneCard : IZoneCard
    {
        /// <summary>
        /// Creates a read-only card collection.
        /// </summary>
        /// <param name="cards">Cards that will be added to the collection.</param>
        public ReadOnlyCardCollection(IEnumerable<TZoneCard> cards) : base(cards.ToList()) { }

        internal ReadOnlyCardCollection() : base(new List<TZoneCard>())
        { }

        internal ReadOnlyCardCollection(TZoneCard card) : base(new List<TZoneCard>() { card }) { }

        #region ReadOnlyCardCollection
        internal ReadOnlyCardCollection<TZoneCard> TappedCards => new ReadOnlyCardCollection<TZoneCard>(Items.Where(card => card is ITappable tappable && tappable.Tapped));
        internal ReadOnlyCardCollection<TZoneCard> UntappedCards => new ReadOnlyCardCollection<TZoneCard>(Items.Where(card => card is ITappable tappable && !tappable.Tapped));
        #endregion ReadOnlyCardCollection

        #region ReadOnlyCreatureCollection
        internal ReadOnlyCreatureCollection<IZoneCreature> Creatures => new ReadOnlyCreatureCollection<IZoneCreature>(Items.Where(card => card is IZoneCreature).Cast<IZoneCreature>());
        //internal ReadOnlyCreatureCollection<IZoneCreature> TappedCreatures => new ReadOnlyCreatureCollection<IZoneCreature>(Creatures.TappedCreatures);
        //internal ReadOnlyCreatureCollection<IZoneCreature> UntappedCreatures => new ReadOnlyCreatureCollection<IZoneCreature>(Creatures.Where(creature => !creature.Tapped));
        internal ReadOnlyCreatureCollection<IZoneCreature> NonEvolutionCreatures => new ReadOnlyCreatureCollection<IZoneCreature>(Creatures.Where(c => !(c is EvolutionCreature)));
        internal ReadOnlyCreatureCollection<IZoneCreature> NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone => new ReadOnlyCreatureCollection<IZoneCreature>(NonEvolutionCreatures.Where(c => c.Cost <= Items.Count));
        #endregion ReadOnlyCreatureCollection
    }
}
