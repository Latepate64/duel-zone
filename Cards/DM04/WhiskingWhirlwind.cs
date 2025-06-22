using Engine;
using Interfaces;

namespace Cards.DM04;

public class WhiskingWhirlwind : Spell
{
    public WhiskingWhirlwind() : base("Whisking Whirlwind", 1, Civilization.Light)
    {
        AddSpellAbilities(new WhiskingWhirlwindEffect());
    }
}
