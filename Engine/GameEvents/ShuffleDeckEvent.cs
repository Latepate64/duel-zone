using System.Linq;

namespace Engine.GameEvents;

public class ShuffleDeckEvent(PlayerV2 player, IRandomizer randomizer) :
    PlayerAction(player)
{
    readonly IRandomizer randomizer = randomizer;

    internal override GameState Happen(GameState state, PlayerAction action)
    {
        // 701.16c If cards in a player’s library are shuffled or otherwise
        // reordered, any revealed cards that are reordered stop being revealed
        // and become new objects.
        // TODO: Become new objects
        var cards = randomizer.Shuffle([.. Player.Deck]);
        return state with
        {
            Players = [.. state.Players.Select(
            x => x == Player ? Player with { Deck = cards } : x  )]
        };
    }
}
