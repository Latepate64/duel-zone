using Interfaces;

namespace Engine.GameEvents;

public class MoveTopCardOfDeckEvent(IPlayerV2 player, ZoneType zoneType) : MoveCardEvent(player, zoneType, false)
{
    internal override ICard RemoveCardFromCurrentZone()
    {
        var card = Player.Deck.TopCard;
        Player.Deck.Remove(card);
        return card;
    }
}