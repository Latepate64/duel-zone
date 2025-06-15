using Engine.Zones;

namespace Engine;

public class PlayerV2
{
    public Deck Deck { get; init; } = new Deck();
    public ShieldZone ShieldZone { get; init; } = new ShieldZone();
    public Hand Hand { get; init; } = new Hand();
    public ManaZone ManaZone { get; init; } = new ManaZone();
    public Graveyard Graveyard { get; init; } = new Graveyard();

    public void SetOwnerForCards()
    {
        Deck.SetOwner(this);
        ShieldZone.SetOwner(this);
        Hand.SetOwner(this);
        ManaZone.SetOwner(this);
        Graveyard.SetOwner(this);
    }
}