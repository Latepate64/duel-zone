using Interfaces;

namespace Cards.DM05;

public class DuringPlayersNextTurnDuration : IDuration
{
    public IDuration Copy()
    {
        return new DuringPlayersNextTurnDuration();
    }
}