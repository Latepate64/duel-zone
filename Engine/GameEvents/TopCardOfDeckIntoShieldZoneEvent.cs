namespace Engine.GameEvents;

public class TopCardOfDeckIntoShieldZoneEvent(PlayerV2 player) : MoveCardEvent(
    player, ZoneType.ShieldZone)
{
    public override ICard RemoveCardFromCurrentZone()
    {
        var card = Player.Deck.TopCard;
        Player.Deck.Remove(card, game: null);
        return card;
    }
}