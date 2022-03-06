using Common;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards
{
    abstract class CardImplementation : Engine.Card
    {
        protected CardImplementation(string name, int manaCost, CardType type)
        {
            CardType = type;
            Civilizations = new List<Civilization>();
            ManaCost = manaCost;
            Name = name;
            Subtypes = new List<Subtype>();
        }

        protected void AddCivilizations(params Civilization[] civilizations)
        {
            Civilizations.AddRange(civilizations);
        }

        protected void AddSubtypes(params Subtype[] subtypes)
        {
            Subtypes.AddRange(subtypes);
        }

        protected void AddAbilities(params Ability[] abilities)
        {
            Abilities.AddRange(abilities);
        }
    }
}
