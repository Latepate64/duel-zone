using Engine.Zones;

namespace Engine;

public interface IPlayerV2
{
    Deck Deck { get; init; }
    ShieldZone ShieldZone { get; init; }
    Hand Hand { get; init; }
    ManaZone ManaZone { get; init; }
    Graveyard Graveyard { get; init; }

    void SetOwnerForCards();
}
