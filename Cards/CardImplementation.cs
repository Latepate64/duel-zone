using Common;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    abstract class CardImplementation : Engine.Card
    {
        protected CardImplementation(CardType type, string name, int manaCost, params Civilization[] civilizations)
        {
            CardType = type;
            Civilizations = civilizations.ToList();
            ManaCost = manaCost;
            Name = name;
            Subtypes = new List<Subtype>();
        }

        protected void AddSubtypes(params Subtype[] subtypes)
        {
            Subtypes.AddRange(subtypes);
        }
    }
}
