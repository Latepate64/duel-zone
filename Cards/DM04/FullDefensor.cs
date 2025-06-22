using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class FullDefensor : Spell
{
    public FullDefensor() : base("Full Defensor", 2, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new FullDefensorEffect());
    }
}
