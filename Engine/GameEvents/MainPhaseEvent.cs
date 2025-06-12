namespace Engine.GameEvents;

public class MainPhaseEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state, PlayerAction action)
    {
        if (action == null)
        {
            // TODO: Return true if nothing can be used
            var complete = index > 0;
            if (!complete)
            {
                PromptedAction = new UseCardEvent(Player);
            }
            ++index;
            return complete;
        }
        else if (action is UseCardEvent chargeEvent)
        {
            if (chargeEvent.ChosenCard == null)
            {
                throw new IllegalActionException(action);
            }
            AddEventThatWouldHappen(chargeEvent);
            return false;
        }
        throw new IllegalActionException(action);
    }
}