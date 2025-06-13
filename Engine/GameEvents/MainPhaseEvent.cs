namespace Engine.GameEvents;

public class MainPhaseEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state)
    {
        state.PassableAction = new UseCardEvent(Player);
        // TODO: Return true if nothing can be used
        return false;
    }
}