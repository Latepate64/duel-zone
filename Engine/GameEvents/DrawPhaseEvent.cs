namespace Engine.GameEvents;

public class DrawPhaseEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state)
    {
        if (index == 0)
        {
            state.EventsThatWouldHappen.Add(new MoveTopCardOfDeckEvent(Player, ZoneType.Hand));
            ++index;
            return false;
        }
        return true;
    }
}