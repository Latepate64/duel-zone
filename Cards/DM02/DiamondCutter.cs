using Engine;
using Interfaces;

namespace Cards.DM02;

public sealed class DiamondCutter : Spell
{
    public DiamondCutter() : base("Diamond Cutter", 5, Civilization.Light)
    {
        AddSpellAbilities(new DiamondCutterOneShotEffect());
    }
}
