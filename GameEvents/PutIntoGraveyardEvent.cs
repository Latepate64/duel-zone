using Interfaces;

namespace GameEvents;

public sealed class PutIntoGraveyardEvent : GameEventV2
{
    public PutIntoGraveyardEvent(IPlayerV2 player, ICard card)
    {
        Player = player;
        Card = card;
    }

    PutIntoGraveyardEvent(PutIntoGraveyardEvent gameEvent)
    {
        Player = gameEvent.Player.Copy();
        Card = gameEvent.Card.Copy();
    }

    public IPlayerV2 Player { get; }

    public ICard Card { get; }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        Player.Graveyard.Add(Card);
        return [];
    }

    public override IGameEventV2 Copy()
    {
        return new PutIntoGraveyardEvent(this);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PutIntoGraveyardEvent e) return false;
        if (!Player.Equals(e.Player)) return false;
        if (!Card.Equals(e.Card)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player, Card);
    }
}