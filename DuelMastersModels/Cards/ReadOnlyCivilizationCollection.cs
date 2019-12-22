using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public class ReadOnlyCivilizationCollection : ReadOnlyCollection<Civilization>
    {
        public ReadOnlyCivilizationCollection(IEnumerable<Civilization> civilizations) : base(civilizations.ToList()) { }
    }
}
