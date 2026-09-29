using Interfaces;

namespace GameEvents;

public sealed class ChargeEvent : PassableGameEvent
{
    public ICard? ChosenCard { get; set; }

    public ChargeEvent(IPlayerV2 player) : base(player)
    {
    }

    public ChargeEvent(ChargeEvent gameEvent) : base(gameEvent)
    {
        ChosenCard = gameEvent.ChosenCard?.Copy();
    }

    public override void Validate(IPassableGameEvent gameEvent)
    {
        var charge = IllegalActionException.ThrowIfNotOfType<ChargeEvent>(
            gameEvent);
        // TODO: Consider that card may not be in hand
        IllegalActionException.ThrowIf(charge, charge.ChosenCard == null,
            IllegalActionType.ChosenCardIsNull);
        IllegalActionException.ThrowIf(charge,
            !Player.Hand.Contains(charge.ChosenCard!),
            IllegalActionType.HandDoesNotContainCard);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ChargeEvent e) return false;
        if (ChosenCard != e.ChosenCard) return false;
        return true;
    }

    public override IGameEventV2 Copy()
    {
        return new ChargeEvent(this);
    }

    public override IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        var card = RemoveCardFromCurrentZone();
        // TODO: Multicolored tapped
        if (card != null)
        {
            Player.ManaZone.Add(card);
        }
        return [];
    }

    internal ICard? RemoveCardFromCurrentZone()
    {
        // TODO: Consider that card may not be in hand
        if (ChosenCard != null)
        {
            Player.Hand.Remove(ChosenCard);
        }
        return ChosenCard;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), ChosenCard?.GetHashCode());
    }
}