using System.Collections.Generic;

namespace Engine.GameEvents;

public class ShuffleDeckEvent(PlayerV2 player, IRandomizer randomizer) : PlayerAction(player, false)
{
    readonly IRandomizer randomizer = randomizer;

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        // 701.16c If cards in a player’s library are shuffled or otherwise
        // reordered, any revealed cards that are reordered stop being revealed
        // and become new objects.
        // TODO: Become new objects
        Player.Deck.Shuffle(randomizer);
        return [];
    }
}
