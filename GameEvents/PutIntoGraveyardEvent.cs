using Interfaces;

namespace GameEvents;

public sealed class PutIntoGraveyardEvent : GameEventV2
{
    public ICard Card { get; }

    public PutIntoGraveyardEvent(IPlayerV2 player, ICard card) : base(player)
    {
        Card = card;
    }

    PutIntoGraveyardEvent(PutIntoGraveyardEvent gameEvent) : base(gameEvent)
    {
        Card = gameEvent.Card.Copy();
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not PutIntoGraveyardEvent e) return false;
        if (Card != e.Card) return false;
        return true;
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        Player.Graveyard.Add(Card);
        return [];
    }

    public override IGameEventV2 Copy()
    {
        return new PutIntoGraveyardEvent(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Card.GetHashCode());
    }
}