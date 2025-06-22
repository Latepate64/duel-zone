using Engine;
using Interfaces;

namespace Cards.DM06;

public class IntenseEvil : Spell
{
    public IntenseEvil() : base("Intense Evil", 3, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new IntenseEvilEffect());
    }
}
