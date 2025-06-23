using Engine.GameEvents;
using Interfaces;

namespace Cards.DM09;

public sealed class MihailEvent : GameEvent
{
    public override void Happen(IGame game)
    {
        // Do nothing
    }

    public override string ToString()
    {
        return "It stays in the battle zone instead.";
    }
}
