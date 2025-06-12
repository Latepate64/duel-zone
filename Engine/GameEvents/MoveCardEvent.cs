using System;

namespace Engine.GameEvents;

public abstract class MoveCardEvent(PlayerV2 player, ZoneType destination) : PlayerAction(player)
{
    public ZoneType Destination { get; } = destination;

    public abstract ICard RemoveCardFromCurrentZone();

    internal override bool Happen(GameState state, PlayerAction action)
    {
        var card = RemoveCardFromCurrentZone();
        if (card == null)
        {
            return true;
        }
        if (Destination == ZoneType.Hand)
        {
            Player.Hand.Add(card, game: null);
        }
        else if (Destination == ZoneType.ManaZone)
        {
            Player.ManaZone.Add(card, game: null);
        }
        else if (Destination == ZoneType.ShieldZone)
        {
            Player.ShieldZone.Add(card, game: null);
        }
        else
        {
            throw new NotImplementedException();
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is MoveCardEvent moveCardEvent
            && Destination == moveCardEvent.Destination;
    }
}