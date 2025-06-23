using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class ClonedDeflector : Spell
{
    public ClonedDeflector() : base("Cloned Deflector", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new ClonedDeflectorEffect(Name));
    }
}
