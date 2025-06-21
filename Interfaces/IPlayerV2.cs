using Interfaces.Zones;

namespace Interfaces;

public interface IPlayerV2
{
    IDeck Deck { get; init; }
    IShieldZone ShieldZone { get; init; }
    IHand Hand { get; init; }
    IManaZone ManaZone { get; init; }
    IGraveyard Graveyard { get; init; }

    void SetOwnerForCards();
}
