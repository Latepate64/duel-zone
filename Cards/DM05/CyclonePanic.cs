using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class CyclonePanic : Spell
{
    public CyclonePanic() : base("Cyclone Panic", 3, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(new CyclonePanicEffect());
    }
}
