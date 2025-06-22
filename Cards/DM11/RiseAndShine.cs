using Engine;
using Interfaces;

namespace Cards.DM11;

public class RiseAndShine : Spell
{
    public RiseAndShine() : base("Rise and Shine", 4, Civilization.Light, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new RiseAndShineEffect());
    }
}
