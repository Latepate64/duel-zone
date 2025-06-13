namespace Engine.GameEvents;

public class ChargePhaseEvent(PlayerV2 player) : PlayerAction(player)
{
    bool prompted;

    internal override bool Happen(GameState state)
    {
        if (!prompted)
        {
            PassableAction = new ChargeEvent(Player);
            prompted = true;
            return false;
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj) && obj is ChargePhaseEvent e && e.prompted == prompted;
    }
}