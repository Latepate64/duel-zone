using Interfaces;

namespace Cards;

public class UntilStartOfPlayersNextTurn : IDuration
{
    public IDuration Copy()
    {
        return new UntilStartOfPlayersNextTurn();
    }
}