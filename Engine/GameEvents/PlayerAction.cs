namespace Engine.GameEvents;

public abstract class PlayerAction(PlayerV2 player) : GameEventV2
{
    public PlayerV2 Player { get; } = player;
}