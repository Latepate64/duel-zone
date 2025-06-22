using Engine;
using Interfaces;

namespace Cards.DM04;

public class SwordOfMalevolentDeath : Spell
{
    public SwordOfMalevolentDeath() : base("Sword of Malevolent Death", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new SwordOfMalevolentDeathOneShotEffect());
    }
}
