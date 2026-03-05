using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class RainOfArrows : Spell
{
    public RainOfArrows() : base("Rain of Arrows", 2, Civilization.Light)
    {
        AddSpellAbilities(new RainOfArrowsEffect());
    }
}
