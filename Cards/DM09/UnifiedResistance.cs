using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class UnifiedResistance : Spell
{
    public UnifiedResistance() : base("Unified Resistance", 2, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new UnifiedResistanceOneShotEffect());
    }
}
