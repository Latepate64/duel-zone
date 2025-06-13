namespace Engine.GameEvents;

public class StartOfTurnEvent(PlayerV2 player) : PlayerAction(player)
{
    internal override bool Happen(GameState state)
    {
        // 1.1) Remove any summoning sickness from your creatures in the battle zone.
        // 1.2) You must untap each of your cards in the battle zone and your mana zone.
        // 1.3) Any abilities that trigger "At the start of your turn" or "At the start of your opponent's turn" are resolved now.
        return true;
    }
}