using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class RainbowStone : Spell
{
    public RainbowStone() : base("Rainbow Stone", 4, Civilization.Nature)
    {
        AddSpellAbilities(new RainbowStoneEffect());
    }
}
