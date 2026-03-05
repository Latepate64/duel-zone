using Interfaces;

namespace GameEvents;

public abstract class MoveCardEvent : GameEventV2
{
    public ZoneType Destination { get; }

    public MoveCardEvent(IPlayerV2 player, ZoneType destination, bool passable) : base(player, passable)
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
            state.ContinuousEffects.Add(card, [.. card.GetAbilities<IStaticAbility>().Where(
                x => x.FunctionZone == ZoneType.BattleZone)]);
            return [];
        }
        throw new NotImplementedException();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is MoveCardEvent moveCardEvent
            && Destination == moveCardEvent.Destination;
    }
}