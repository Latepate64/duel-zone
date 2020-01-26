using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Read-only collection that contains civilizations.
    /// </summary>
    public class ReadOnlyCivilizationCollection : ReadOnlyCollection<Civilization>
    {
        internal ReadOnlyCivilizationCollection(IEnumerable<Civilization> civilizations) : base(civilizations.ToList()) { }
    }
}
