namespace Engine.GameEvents;

public class ChargeEvent(PlayerV2 player, bool passable = true) : MoveCardEvent(player, ZoneType.ManaZone, passable)
{
    public ICard ChosenCard { get; set; }

    internal override ICard RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        Player.Hand.Remove(ChosenCard, game: null);
        return ChosenCard;
    }

    internal override bool IsLegal(GameEventV2 gameEvent)
    {
        return gameEvent is ChargeEvent charge && Player.Hand.Cards.Contains(charge.ChosenCard);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is ChargeEvent e
            && ChosenCard == e.ChosenCard;
    }
}