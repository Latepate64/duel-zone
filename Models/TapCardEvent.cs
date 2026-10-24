using Interfaces;

namespace Models;

public class TapCardEvent(ICard card) : IGameEvent
{
    public ICard Card { get; set; } = card;

    public IGameEvent Copy()
    {
        return new TapCardEvent(Card);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TapCardEvent tap) return false;
        if (!Card.Equals(tap.Card)) return false;
        return true;
    }
}
