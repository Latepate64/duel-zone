using Interfaces.Zones;

namespace Interfaces;

public interface IPlayer : IAttackable
{
    IDeck Deck { get; }
    IShieldZone ShieldZone { get; }
    IHand Hand { get; }
    IManaZone ManaZone { get; }
    IGraveyard Graveyard { get; }
    IPlayer Opponent { get; }

    IPlayer Copy();
    void SetOwnerForCards();
}
