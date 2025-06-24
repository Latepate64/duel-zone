using Interfaces;

namespace GameEvents;

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
