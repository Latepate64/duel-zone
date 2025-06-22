using Engine;
using Interfaces;

namespace Cards.DM05;

public class CyclonePanic : Spell
{
    public CyclonePanic() : base("Cyclone Panic", 3, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(new CyclonePanicEffect());
    }
}
