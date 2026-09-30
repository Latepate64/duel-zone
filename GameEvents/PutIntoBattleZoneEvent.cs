using Interfaces;

namespace GameEvents;

public sealed class PutIntoBattleZoneEvent : MoveCardEvent
{
    public ICard Card { get; }

    public PutIntoBattleZoneEvent(IPlayerV2 player, ICard card) : base(
        player, ZoneType.BattleZone)
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

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not PutIntoBattleZoneEvent e) return false;
        if (Card != e.Card) return false;
        return true;
    }

    public override IGameEventV2 Copy()
    {
        return new PutIntoBattleZoneEvent(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Card.GetHashCode());
    }
}