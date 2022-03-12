using Common;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    abstract class CardImplementation : Engine.Card
    {
        protected CardImplementation(CardType type, string name, int manaCost, int? power, params Civilization[] civilizations) : base(power)
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
