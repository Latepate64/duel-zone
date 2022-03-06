using Common;

namespace Cards
{
    abstract class Spell : CardImplementation
    {
        protected Spell(string name, int manaCost, params Civilization[] civilizations) : base(CardType.Spell, name, manaCost, civilizations)
        {
        }
    }
}
