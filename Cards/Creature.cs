using Common;
using System.Collections.Generic;

namespace Cards
{
    abstract class Creature : CardImplementation
    {
        /// <summary>
        /// This constructor should be used for cards with one subtype.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        /// <param name="race"></param>
        /// <param name="civilizations"></param>
        protected Creature(string name, int manaCost, int power, Subtype race, params Civilization[] civilizations) : this(name, manaCost, power, civilizations)
        {
            Subtypes.Add(race);
        }

        /// <summary>
        /// This constructor should be used for multicolored cards. Add subtypes for the card in the constructor of the inheritor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        protected Creature(string name, int manaCost, int power, params Civilization[] civilizations) : base(CardType.Creature, name, manaCost, power, civilizations)
        {
            Power = power;
        }
    }
}
