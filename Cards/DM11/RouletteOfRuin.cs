using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class RouletteOfRuin : Spell
{
    public RouletteOfRuin() : base("Roulette of Ruin", 5, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new RouletteOfRuinEffect());
    }
}
