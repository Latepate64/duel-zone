namespace Engine.GameEvents;

public class ChargeEvent(PlayerV2 player) : MoveCardEvent(player, ZoneType.ManaZone)
{
    public Card ChosenCard { get; set; }

    internal override ICard RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        Player.Hand.Remove(ChosenCard, game: null);
        return ChosenCard;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is ChargeEvent e
            && ChosenCard == e.ChosenCard;
    }
}