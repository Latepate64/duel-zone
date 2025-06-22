using Engine;
using Interfaces;

namespace Cards.DM11;

public class RouletteOfRuin : Spell
{
    public RouletteOfRuin() : base("Roulette of Ruin", 5, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new RouletteOfRuinEffect());
    }
}
