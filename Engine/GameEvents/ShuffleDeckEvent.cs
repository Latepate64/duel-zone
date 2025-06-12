namespace Engine.GameEvents;

public class ShuffleDeckEvent(PlayerV2 player, IRandomizer randomizer) :
    PlayerAction(player)
{
    readonly IRandomizer randomizer = randomizer;

    internal override bool Happen(GameState state, PlayerAction action)
    {
        // 701.16c If cards in a player’s library are shuffled or otherwise
        // reordered, any revealed cards that are reordered stop being revealed
        // and become new objects.
        // TODO: Become new objects
        Player.Deck.Shuffle(randomizer);
        return true;
    }
}
