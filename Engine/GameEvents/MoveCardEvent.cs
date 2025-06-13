using System;
using System.Collections.Generic;

namespace Engine.GameEvents;

public abstract class MoveCardEvent(PlayerV2 player, ZoneType destination, bool passable) :
    PlayerAction(player, passable)
{
    public ZoneType Destination { get; } = destination;

    internal abstract ICard RemoveCardFromCurrentZone();

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        var card = RemoveCardFromCurrentZone();
        if (card == null)
        {
            return [];
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
        return [];
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is MoveCardEvent moveCardEvent
            && Destination == moveCardEvent.Destination;
    }
}