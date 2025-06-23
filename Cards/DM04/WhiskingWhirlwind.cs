using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class WhiskingWhirlwind : Spell
{
    public WhiskingWhirlwind() : base("Whisking Whirlwind", 1, Civilization.Light)
    {
        AddSpellAbilities(new WhiskingWhirlwindEffect());
    }
}
