using Interfaces;

namespace GameEvents;

public sealed class ShuffleDeckEvent(IPlayerV2 player, IRandomizer randomizer) : GameEventV2(player, false)
{
    readonly IRandomizer randomizer = randomizer;

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        // 701.16c If cards in a player’s library are shuffled or otherwise
        // reordered, any revealed cards that are reordered stop being revealed
        // and become new objects.
        // TODO: Become new objects
        Player.Deck.Shuffle(randomizer);
        return [];
    }
}
