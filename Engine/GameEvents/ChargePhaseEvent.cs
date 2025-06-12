namespace Engine.GameEvents;

public class ChargePhaseEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state, PlayerAction action)
    {
        if (action == null)
        {
            var complete = index > 0;
            if (!complete)
            {
                PromptedAction = new ChargeEvent(Player);
            }
            ++index;
            return complete;
        }
        else if (action is ChargeEvent chargeEvent)
        {
            if (chargeEvent.ChosenCard == null)
            {
                throw new IllegalActionException(action);
            }
            AddEventThatWouldHappen(chargeEvent);
        }
        throw new IllegalActionException(action);
    }
}