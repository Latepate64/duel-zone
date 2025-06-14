namespace Engine.GameEvents;

public class PutIntoBattleZoneEvent(PlayerV2 player, bool passable, ICard card) :
    MoveCardEvent(player, ZoneType.BattleZone, passable)
{
    public ICard Card { get; } = card;

    internal override ICard RemoveCardFromCurrentZone()
    {
        Player.Hand.Remove(Card, null); // TODO: May not be in hand always
        return Card;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoBattleZoneEvent e
            && Card == e.Card;
    }
}