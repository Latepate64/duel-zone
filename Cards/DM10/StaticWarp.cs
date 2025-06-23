using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class StaticWarp : Spell
{
    public StaticWarp() : base("Static Warp", 2, Civilization.Light)
    {
        AddSpellAbilities(new StaticWarpEffect());
    }
}
