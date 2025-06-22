using Engine;
using Interfaces;

namespace Cards.DM10;

public class StaticWarp : Spell
{
    public StaticWarp() : base("Static Warp", 2, Civilization.Light)
    {
        AddSpellAbilities(new StaticWarpEffect());
    }
}
