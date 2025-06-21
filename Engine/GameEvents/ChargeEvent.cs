using Interfaces;

namespace Engine.GameEvents;

public class ChargeEvent(IPlayerV2 player, bool passable = true) : MoveCardEvent(player, ZoneType.ManaZone, passable)
{
    public ICard ChosenCard { get; set; }

    internal override ICard RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        Player.Hand.Remove(ChosenCard);
        return ChosenCard;
    }

    internal override void Validate(GameEventV2 gameEvent)
    {
        var charge = IllegalActionException.ThrowIfNotOfType<ChargeEvent>(gameEvent);
        // TODO: Consider that card may not be in hand
        IllegalActionException.ThrowIf(charge, !Player.Hand.Contains(charge.ChosenCard),
            IllegalActionType.HandDoesNotContainCard);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is ChargeEvent e
            && ChosenCard == e.ChosenCard;
    }
}