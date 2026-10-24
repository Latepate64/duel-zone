using Interfaces;

namespace Models;

public class MoveCardEvent(ICard card, ZoneType source, ZoneType destination) : IGameEvent
{
    public ICard Card { get; } = card;
    public ZoneType Source { get; } = source;
    public ZoneType Destination { get; } = destination;

    public MoveCardEvent Copy()
    {
        return new MoveCardEvent(Card.Copy(), Source, Destination);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MoveCardEvent move) return false;
        if (!Card.Equals(move.Card)) return false;
        if (Source != move.Source) return false;
        if (Destination != move.Destination) return false;
        return true;
    }
}