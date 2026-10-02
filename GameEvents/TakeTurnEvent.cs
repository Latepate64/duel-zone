using Interfaces;

namespace GameEvents;

public sealed class TakeTurnEvent : GameEventV2
{
    public bool SkipDrawPhase { get; }
    public PhaseType NextPhase { get; private set; }

    public TakeTurnEvent(IPlayerV2 player, bool skipDrawPhase,
        PhaseType nextPhase = PhaseType.StartOfTurn) : base(player)
    {
        SkipDrawPhase = skipDrawPhase;
        NextPhase = nextPhase;
    }

    TakeTurnEvent(TakeTurnEvent gameEvent) : base(gameEvent)
    {
        NextPhase = gameEvent.NextPhase;
        SkipDrawPhase = gameEvent.SkipDrawPhase;
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (NextPhase == PhaseType.StartOfTurn)
        {
            NextPhase = PhaseType.Draw;
            return [new StartOfTurnEvent(Player)];
        }
        if (NextPhase == PhaseType.Draw)
        {
            NextPhase = PhaseType.Charge;
            if (!SkipDrawPhase)
            {
                return [new DrawPhaseEvent(Player)];
            }
        }
        if (NextPhase == PhaseType.Charge)
        {
            NextPhase = PhaseType.Main;
            return [new ChargePhaseEvent(Player)];
        }
        if (NextPhase == PhaseType.Main)
        {
            NextPhase = PhaseType.Attack;
            return [new MainPhaseEvent(Player)];
        }
        if (NextPhase == PhaseType.Attack)
        {
            NextPhase = PhaseType.EndOfTurn;
            return [new AttackPhaseEvent(Player)];
        }
        return [];
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not TakeTurnEvent e) return false;
        if (SkipDrawPhase != e.SkipDrawPhase) return false;
        if (NextPhase != e.NextPhase) return false;
        return true;
    }

    public override IGameEventV2 Copy()
    {
        return new TakeTurnEvent(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            base.GetHashCode(),
            SkipDrawPhase.GetHashCode(),
            NextPhase.GetHashCode());
    }
}