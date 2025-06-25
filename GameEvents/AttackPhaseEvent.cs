using Interfaces;

namespace GameEvents;

public sealed class AttackPhaseEvent : GameEventV2
{
    public AttackPhaseEvent(IPlayerV2 player) : base(player, false)
    {
    }

    AttackPhaseEvent(IGameEventV2 gameEvent) : base(gameEvent)
    {
    }

    public override IGameEventV2 Copy()
    {
        return new AttackPhaseEvent(this);
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        // TODO: Check if the creatures actually have a legal way to attack
        // TODO: Consider that creature with summoning sickness may be able to attack
        var creatures = state.BattleZone.GetUntappedCreatures(state.ActivePlayer);
        if (creatures.Any(x => !x.SummoningSickness))
        {
            return [new AttackEvent(Player)];
        }
        return [];
    }
}