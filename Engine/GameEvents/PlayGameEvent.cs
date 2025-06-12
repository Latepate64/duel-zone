namespace Engine.GameEvents;

public class PlayGameEvent() : GameEventV2()
{
    int turnNumber;

    internal override bool Happen(GameState state, PlayerAction action)
    {
        AddEventThatWouldHappen(new TakeTurnEvent(state.ActivePlayer, ++turnNumber));
        return false;
    }
}