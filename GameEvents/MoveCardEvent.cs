using Interfaces;

namespace GameEvents;

public abstract class MoveCardEvent : GameEventV2
{
    public MoveCardEvent(IPlayerV2 player, ZoneType destination)
    {
        Player = player;
        Destination = destination;
    }

    protected MoveCardEvent(MoveCardEvent gameEvent)
    {
        Player = gameEvent.Player.Copy();
        Destination = gameEvent.Destination;
    }

    public IPlayerV2 Player { get; }

    public ZoneType Destination { get; }

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
        if (obj is not MoveCardEvent moveCardEvent) return false;
        if (Destination != moveCardEvent.Destination) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player, Destination);
    }
}