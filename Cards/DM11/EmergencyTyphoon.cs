using Engine;
using Interfaces;

namespace Cards.DM11;

public class EmergencyTyphoon : Spell
{
    public EmergencyTyphoon() : base("Emergency Typhoon", 2, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new EmergencyTyphoonEffect());
    }
}
