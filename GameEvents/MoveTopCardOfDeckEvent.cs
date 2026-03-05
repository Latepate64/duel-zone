using Interfaces;

namespace GameEvents;

public sealed class MoveTopCardOfDeckEvent : MoveCardEvent
{
    MoveTopCardOfDeckEvent(MoveCardEvent gameEvent) : base(gameEvent)
    {
    }

    public MoveTopCardOfDeckEvent(IPlayerV2 player, ZoneType zoneType) : base(player, zoneType, false)
    {
    }

    internal override ICard? RemoveCardFromCurrentZone()
    {
        var card = Player.Deck.TopCard;
        Player.Deck.Remove(card);
        return card;
    }

    public override IGameEventV2 Copy()
    {
        return new MoveTopCardOfDeckEvent(this);
    }
}