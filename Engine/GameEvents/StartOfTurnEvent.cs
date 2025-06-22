using System.Collections.Generic;
using Interfaces;

namespace Engine.GameEvents;

public sealed class StartOfTurnEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        // 1.1) Remove any summoning sickness from your creatures in the battle zone.
        // 1.2) You must untap each of your cards in the battle zone and your mana zone.
        // 1.3) Any abilities that trigger "At the start of your turn" or "At the start of your opponent's turn" are resolved now.
        return [];
    }
}