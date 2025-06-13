namespace Engine.GameEvents;

public enum PhaseType
{
    StartOfTurn,
    Draw,
    Charge,
    Main
}

public class TakeTurnEvent(PlayerV2 player, int turnNumber) : PlayerAction(player)
{
    public int TurnNumber { get; } = turnNumber;
    public PhaseType NextPhase { get; set; }

    internal override bool Happen(GameState state)
    {
        if (NextPhase == PhaseType.StartOfTurn)
        {
            NextPhase = PhaseType.Draw;
            AddEventThatWouldHappen(new StartOfTurnEvent(Player));
            return false;
        }
        if (NextPhase == PhaseType.Draw)
        {
            NextPhase = PhaseType.Charge;
            if (TurnNumber > 1)
            {
                AddEventThatWouldHappen(new DrawPhaseEvent(Player));
                return false;
            }
        }
        if (NextPhase == PhaseType.Charge)
        {
            NextPhase = PhaseType.Main;
            AddEventThatWouldHappen(new ChargePhaseEvent(Player));
            return false;
        }
        if (NextPhase == PhaseType.Main)
        {
            // NextPhase = Phase.Main;
            AddEventThatWouldHappen(new MainPhaseEvent(Player));
            return false;
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is TakeTurnEvent e
            && TurnNumber == e.TurnNumber
            && NextPhase == e.NextPhase;
    }
}