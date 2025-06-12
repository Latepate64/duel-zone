namespace Engine.GameEvents;

public class TakeTurnEvent(PlayerV2 player, int turnNumber) : PlayerAction(player)
{
    public int TurnNumber { get; } = turnNumber;

    internal override bool Happen(GameState state, PlayerAction action)
    {
        if (index == 0)
        {
            ++index;
            AddEventThatWouldHappen(new StartOfTurnEvent(Player));
            return false;
        }
        if (index == 1)
        {
            ++index;
            if (TurnNumber > 1)
            {
                AddEventThatWouldHappen(new DrawPhaseEvent(Player));
                return false;
            }
        }
        if (index == 2)
        {
            ++index;
            AddEventThatWouldHappen(new ChargePhaseEvent(Player));
            return false;
        }
        return true;
    }
}