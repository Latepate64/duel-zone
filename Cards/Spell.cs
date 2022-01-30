using Engine;
using System.Collections.Generic;

namespace Cards
{
    public abstract class Spell : Card
    {
        protected Spell(string name, int manaCost, Civilization civilization)
        {
            CardType = CardType.Spell;
            Civilizations = new List<Civilization> { civilization };
            ManaCost = manaCost;
            Name = name;
        }
    }
}
