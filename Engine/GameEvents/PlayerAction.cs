namespace Engine.GameEvents;

public abstract class PlayerAction(PlayerV2 player) : GameEventV2
{
    public PlayerV2 Player { get; } = player;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PlayerAction action
            && Player == action.Player;
    }
}