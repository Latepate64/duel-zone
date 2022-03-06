using Common;

namespace Cards
{
    abstract class Spell : CardImplementation
    {
        protected Spell(string name, int manaCost, Civilization civilization) : base(name, manaCost, CardType.Spell)
        {
            Civilizations.Add(civilization);
        }
    }
}
