using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Read-only collection that contains creatures.
    /// </summary>
    public class ReadOnlyCreatureCollection<TCreature> : ReadOnlyCollection<TCreature> where TCreature : ICreature
    {
        internal ReadOnlyCreatureCollection(TCreature creature) : base(new List<TCreature>() { creature }) { }

        internal ReadOnlyCreatureCollection(IEnumerable<TCreature> creatures) : base(creatures.ToList()) { }

        internal ReadOnlyCreatureCollection<TCreature> TappedCreatures => new ReadOnlyCreatureCollection<TCreature>(Items.Where(creature => creature is ITappable tappable && tappable.Tapped));
    }
}
