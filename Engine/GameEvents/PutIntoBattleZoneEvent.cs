namespace Engine.GameEvents;

public class PutIntoBattleZoneEvent(PlayerV2 player, bool passable, Card card) :
    MoveCardEvent(player, ZoneType.BattleZone, passable)
{
    public Card Card { get; } = card;

    internal override Card RemoveCardFromCurrentZone()
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
}