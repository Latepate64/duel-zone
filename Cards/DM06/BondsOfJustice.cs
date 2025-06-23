using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class BondsOfJustice : Spell
{
    public BondsOfJustice() : base("Bonds of Justice", 4, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new BondsOfJusticeEffect());
    }
}
