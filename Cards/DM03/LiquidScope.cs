using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class LiquidScope : Spell
{
    public LiquidScope() : base("Liquid Scope", 4, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new LiquidScopeEffect());
    }
}
