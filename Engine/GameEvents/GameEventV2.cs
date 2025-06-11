namespace Engine.GameEvents;

public abstract class GameEventV2
{
    internal abstract GameState Happen(GameState state, PlayerAction action);
}