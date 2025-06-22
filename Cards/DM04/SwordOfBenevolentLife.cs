using Engine;
using Interfaces;

namespace Cards.DM04;

public class SwordOfBenevolentLife : Spell
{
    public SwordOfBenevolentLife() : base("Sword of Benevolent Life", 2, Civilization.Nature)
    {
        AddSpellAbilities(new SwordOfBenevolentLifeEffect());
    }
}
