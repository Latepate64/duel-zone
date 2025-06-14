namespace Engine.GameEvents;

public class ChargeEvent(PlayerV2 player, bool passable = true) : MoveCardEvent(player, ZoneType.ManaZone, passable)
{
    public Card ChosenCard { get; set; }

    internal override Card RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        Player.Hand.Remove(ChosenCard, game: null);
        return ChosenCard;
    }

    internal override void Validate(GameEventV2 gameEvent)
    {
        var charge = IllegalActionException.ThrowIfNotOfType<ChargeEvent>(gameEvent);
        // TODO: Consider that card may not be in hand
        IllegalActionException.ThrowIf(gameEvent, !Player.Hand.Cards.Contains(charge.ChosenCard),
            IllegalActionType.HandDoesNotContainCard);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is ChargeEvent e
            && ChosenCard == e.ChosenCard;
    }
}