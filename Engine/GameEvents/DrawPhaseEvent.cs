namespace Engine.GameEvents;

public class DrawPhaseEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state, PlayerAction action)
    {
        if (index == 0)
        {
            AddEventThatWouldHappen(new MoveTopCardOfDeckEvent(Player, ZoneType.Hand));
            ++index;
            return false;
        }
        return true;
    }
}