namespace Engine.GameEvents;

public class MoveTopCardOfDeckEvent(PlayerV2 player, ZoneType zoneType) : MoveCardEvent(player, zoneType, false)
{
    internal override ICard RemoveCardFromCurrentZone()
    {
        var card = Player.Deck.TopCard;
        Player.Deck.Remove(card, game: null);
        return card;
    }
}