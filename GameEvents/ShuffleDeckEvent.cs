using Interfaces;

namespace GameEvents;

public sealed class ShuffleDeckEvent : GameEventV2
{
    public ShuffleDeckEvent(IPlayerV2 player, IRandomizer randomizer)
    {
        Player = player;
        this.randomizer = randomizer;
    }

    ShuffleDeckEvent(ShuffleDeckEvent gameEvent)
    {
        Player = gameEvent.Player.Copy();
        randomizer = gameEvent.randomizer;
    }

    public IPlayerV2 Player { get; }

    readonly IRandomizer randomizer;

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

    public override bool Equals(object? obj)
    {
        if (obj is not ShuffleDeckEvent passable) return false;
        if (!Player.Equals(passable.Player)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player);
    }
}
