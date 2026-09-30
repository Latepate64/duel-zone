using Interfaces;

namespace GameEvents;

public abstract class MoveCardEvent : GameEventV2
{
    public ZoneType Destination { get; }

    public MoveCardEvent(IPlayerV2 player, ZoneType destination) : base(player)
    {
        Destination = destination;
    }

    protected MoveCardEvent(MoveCardEvent gameEvent) : base(gameEvent)
    {
        Destination = gameEvent.Destination;
    }

    internal abstract ICard? RemoveCardFromCurrentZone();

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        var card = RemoveCardFromCurrentZone();
        if (card == null)
        {
            return [];
        }
        if (Destination == ZoneType.Hand)
        {
            Player.Hand.Add(card);
            return [];
        }
        if (Destination == ZoneType.ManaZone)
        {
            // TODO: Multicolored tapped
            Player.ManaZone.Add(card);
            return [];
        }
        if (Destination == ZoneType.ShieldZone)
        {
            // TODO: Face down
            Player.ShieldZone.Add(card);
            return [];
        }
        if (Destination == ZoneType.BattleZone)
        {
            state.BattleZone.Add(card);
            state.ContinuousEffects.Add(
                card, [.. card.GetAbilities<IStaticAbility>().Where(
                    x => x.FunctionZone == ZoneType.BattleZone)]);
            return [];
        }
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not MoveCardEvent moveCardEvent) return false;
        if (Destination != moveCardEvent.Destination) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Destination.GetHashCode());
    }
}