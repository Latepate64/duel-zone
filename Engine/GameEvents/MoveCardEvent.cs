using System;

namespace Engine.GameEvents;

public abstract class MoveCardEvent(PlayerV2 player, ZoneType destination) :
    PlayerAction(player)
{
    public ZoneType Destination { get; } = destination;

    public abstract ICard RemoveCardFromCurrentZone();

    internal override void Happen(GameState state, PlayerAction action = null)
    {
        var card = RemoveCardFromCurrentZone();
        if (card == null)
        {
            return;
        }
        if (Destination == ZoneType.Hand)
        {
            Player.Hand.Add(card, game: null);
        }
        else if (Destination == ZoneType.ShieldZone)
        {
            Player.ShieldZone.Add(card, game: null);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}