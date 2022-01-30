using DuelMastersModels;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public abstract class Creature : Card
    {
        protected Creature(string name, int manaCost, Civilization civilization, int power, Subtype race) : this(name, manaCost, new List<Civilization> { civilization }, power, new List<Subtype> { race })
        {
        }

        protected Creature(string name, int manaCost, IEnumerable<Civilization> civilizations, int power, IEnumerable<Subtype> races)
        {
            CardType = CardType.Creature;
            Civilizations = civilizations.ToList();
            ManaCost = manaCost;
            Name = name;
            Power = power;
            Subtypes = races.ToList();
        }
    }
}
