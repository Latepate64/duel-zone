namespace Engine.GameEvents;

public class UseCardEvent(PlayerV2 player) : MoveCardEvent(player, ZoneType.SpellStack, true)
{
    public Card ChosenCard { get; set; }

    internal override ICard RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        Player.Hand.Remove(ChosenCard, game: null);
        return ChosenCard;
    }

    internal override bool IsLegal(GameEventV2 gameEvent)
    {
        return gameEvent is UseCardEvent use && Player.Hand.Cards.Contains(use.ChosenCard);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is UseCardEvent e
            && ChosenCard == e.ChosenCard;
    }
}