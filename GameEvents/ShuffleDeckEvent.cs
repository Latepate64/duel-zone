using Interfaces;

namespace GameEvents;

public sealed class ShuffleDeckEvent : GameEventV2
{
    readonly IRandomizer randomizer;

    ShuffleDeckEvent(ShuffleDeckEvent gameEvent) : base(gameEvent)
    {
        randomizer = gameEvent.randomizer.Copy();
    }

    public ShuffleDeckEvent(IPlayerV2 player, IRandomizer randomizer) : base(player, false)
    {
        this.randomizer = randomizer;
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        // 701.16c If cards in a player’s library are shuffled or otherwise
        // reordered, any revealed cards that are reordered stop being revealed
        // and become new objects.
        // TODO: Become new objects
        Player.Deck.Shuffle(randomizer);
        return [];
    }

    public override IGameEventV2 Copy()
    {
        return new ShuffleDeckEvent(this);
    }
}
