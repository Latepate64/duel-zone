using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class ProtectiveForce : Spell
{
    public ProtectiveForce() : base("Protective Force", 1, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new ProtectiveForceEffect());
    }
}
