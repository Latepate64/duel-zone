using Engine;
using Interfaces;

namespace Cards.DM09;

public class UnifiedResistance : Spell
{
    public UnifiedResistance() : base("Unified Resistance", 2, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new UnifiedResistanceOneShotEffect());
    }
}
