using System.Collections.Generic;

namespace Engine.GameEvents;

public enum PhaseType
{
    StartOfTurn,
    Draw,
    Charge,
    Main
}

public class TakeTurnEvent(PlayerV2 player, int turnNumber) : GameEventV2(player, false)
{
    public int TurnNumber { get; } = turnNumber;
    public PhaseType NextPhase { get; set; }

    internal override IEnumerable<GameEventV2> Happen(GameState state)
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
            // NextPhase = Phase.Main;
            return [new MainPhaseEvent(Player)];
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
}