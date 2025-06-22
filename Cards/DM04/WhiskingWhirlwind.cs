using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class WhiskingWhirlwind : Spell
{
    public WhiskingWhirlwind() : base("Whisking Whirlwind", 1, Civilization.Light)
    {
        AddSpellAbilities(new WhiskingWhirlwindEffect());
    }
}
