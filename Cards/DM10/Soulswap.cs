using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class Soulswap : Spell
{
    public Soulswap() : base("Soulswap", 3, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(new SoulswapEffect());
    }
}
