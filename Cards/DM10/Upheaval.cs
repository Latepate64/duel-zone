using Engine;
using Interfaces;

namespace Cards.DM10;

public class Upheaval : Spell
{
    public Upheaval() : base("Upheaval", 6, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new UpheavalEffect());
    }
}
