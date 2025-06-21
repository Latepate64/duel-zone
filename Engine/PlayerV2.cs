using Engine.Zones;
using Interfaces;
using Interfaces.Zones;

namespace Engine;

public class PlayerV2 : IPlayerV2
{
    public IDeck Deck { get; init; } = new Deck();
    public IShieldZone ShieldZone { get; init; } = new ShieldZone();
    public IHand Hand { get; init; } = new Hand();
    public IManaZone ManaZone { get; init; } = new ManaZone();
    public IGraveyard Graveyard { get; init; } = new Graveyard();

    public void SetOwnerForCards()
    {
        Deck.SetOwner(this);
        ShieldZone.SetOwner(this);
        Hand.SetOwner(this);
        ManaZone.SetOwner(this);
        Graveyard.SetOwner(this);
    }
}