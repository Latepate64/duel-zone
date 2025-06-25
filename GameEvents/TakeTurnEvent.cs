using Interfaces;

namespace GameEvents;

public enum PhaseType
{
    StartOfTurn,
    Draw,
    Charge,
    Main,
    Attack,
    EndOfTurn
}

public sealed class TakeTurnEvent : GameEventV2
{
    public int TurnNumber { get; }
    public PhaseType NextPhase { get; set; }

    public TakeTurnEvent(IPlayerV2 player, int turnNumber) : base(player, false)
    {
        TurnNumber = turnNumber;
    }

    TakeTurnEvent(TakeTurnEvent gameEvent) : base(gameEvent)
    {
        NextPhase = gameEvent.NextPhase;
        TurnNumber = gameEvent.TurnNumber;
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
            if (TurnNumber > 1)
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

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is TakeTurnEvent e
            && TurnNumber == e.TurnNumber
            && NextPhase == e.NextPhase;
    }

    public override IGameEventV2 Copy()
    {
        return new TakeTurnEvent(this);
    }
}