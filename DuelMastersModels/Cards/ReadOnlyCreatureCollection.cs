using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Read-only collection that contains creatures.
    /// </summary>
    public class ReadOnlyCreatureCollection<TZoneCreature> : ReadOnlyCollection<TZoneCreature> where TZoneCreature : IZoneCreature
    {
        internal ReadOnlyCreatureCollection(TZoneCreature creature) : base(new List<TZoneCreature>() { creature }) { }

        internal ReadOnlyCreatureCollection(IEnumerable<TZoneCreature> creatures) : base(creatures.ToList()) { }

        internal ReadOnlyCreatureCollection<TZoneCreature> TappedCreatures => new ReadOnlyCreatureCollection<TZoneCreature>(Items.Where(creature => creature is ITappable tappable && tappable.Tapped));
    }
}
