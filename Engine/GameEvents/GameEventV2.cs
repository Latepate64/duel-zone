namespace Engine.GameEvents;

public abstract class GameEventV2
{
    internal abstract void Happen(GameState state, PlayerAction action = null);
}