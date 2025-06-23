using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class IntenseEvil : Spell
{
    public IntenseEvil() : base("Intense Evil", 3, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new IntenseEvilEffect());
    }
}
