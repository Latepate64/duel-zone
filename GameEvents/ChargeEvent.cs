using Interfaces;

namespace GameEvents;

public sealed class ChargeEvent : MoveCardEvent
{
    public ICard? ChosenCard { get; set; }

    public ChargeEvent(IPlayerV2 player, bool passable = true) : base(player, ZoneType.ManaZone, passable)
    {
    }

    public ChargeEvent(ChargeEvent gameEvent) : base(gameEvent)
    {
        ChosenCard = gameEvent.ChosenCard?.Copy();
    }

    internal override ICard? RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        if (ChosenCard != null)
        {
            Player.Hand.Remove(ChosenCard);
        }
        return ChosenCard;
    }

    public override void Validate(IGameEventV2 gameEvent)
    {
        var charge = IllegalActionException.ThrowIfNotOfType<ChargeEvent>(gameEvent);
        // TODO: Consider that card may not be in hand
        IllegalActionException.ThrowIf(charge, charge.ChosenCard == null,
            IllegalActionType.ChosenCardIsNull);
        IllegalActionException.ThrowIf(charge, !Player.Hand.Contains(charge.ChosenCard!),
            IllegalActionType.HandDoesNotContainCard);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is ChargeEvent e
            && ChosenCard == e.ChosenCard;
    }

    public override IGameEventV2 Copy()
    {
        return new ChargeEvent(this);
    }
}