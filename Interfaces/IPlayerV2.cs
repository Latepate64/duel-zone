using Interfaces.Zones;

namespace Interfaces;

public interface IPlayerV2
{
    IDeck Deck { get; }
    IShieldZone ShieldZone { get; }
    IHand Hand { get; }
    IManaZone ManaZone { get; }
    IGraveyard Graveyard { get; }

    IPlayerV2 Copy();
    void SetOwnerForCards();
}
