using Common;

namespace Cards
{
    abstract class Creature : CardImplementation
    {
        /// <summary>
        /// This constructor should be used for monocolored cards with one subtype.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="civilization"></param>
        /// <param name="power"></param>
        /// <param name="race"></param>
        protected Creature(string name, int manaCost, Civilization civilization, int power, Subtype race) : this(name, manaCost, power)
        {
            Civilizations.Add(civilization);
            Subtypes.Add(race);
        }

        /// <summary>
        /// This constructor should be used for multicolored cards. Add civilizations and subtypes for the card in the constructor of the inheritor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        protected Creature(string name, int manaCost, int power) : base(name, manaCost, CardType.Creature)
        {
            Power = power;
        }
    }
}
