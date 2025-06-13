namespace Engine.GameEvents;

public class PassAction(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state)
    {
        return true;
    }
}
