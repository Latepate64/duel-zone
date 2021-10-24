using DuelMastersModels;
using System.Collections.Generic;

namespace DuelMastersCards
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
