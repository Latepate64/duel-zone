using Interfaces;

namespace GameEvents;

public sealed class PutIntoBattleZoneEvent : MoveCardEvent
{
    public ICard Card { get; }

    public PutIntoBattleZoneEvent(IPlayerV2 player, bool passable, ICard card) : base(
        player, ZoneType.BattleZone, passable)
    {
        Card = card;
    }

    PutIntoBattleZoneEvent(PutIntoBattleZoneEvent gameEvent) : base(gameEvent)
    {
        Card = gameEvent.Card.Copy();
    }

    internal override ICard? RemoveCardFromCurrentZone()
    {
        Player.Hand.Remove(Card); // TODO: May not be in hand always
        return Card;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoBattleZoneEvent e
            && Card == e.Card;
    }

    public override IGameEventV2 Copy()
    {
        return new PutIntoBattleZoneEvent(this);
    }
}