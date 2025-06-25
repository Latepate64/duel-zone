using Interfaces;

namespace GameEvents;

public sealed class PutIntoGraveyardEvent : GameEventV2
{
    public ICard Card { get; }

    public PutIntoGraveyardEvent(IPlayerV2 player, ICard card) : base(player, false)
    {
        Card = card;
    }

    PutIntoGraveyardEvent(PutIntoGraveyardEvent gameEvent) : base(gameEvent)
    {
        Card = gameEvent.Card.Copy();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoGraveyardEvent e
            && Card == e.Card;
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
}