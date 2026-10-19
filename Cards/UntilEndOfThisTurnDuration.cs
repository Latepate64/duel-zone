using Interfaces;

namespace Cards;

public class UntilEndOfThisTurnDuration : IDuration
{
    public IDuration Copy()
    {
        return new UntilEndOfThisTurnDuration();
    }
}