using System.Collections.Generic;
using Engine.Zones;

namespace Engine;

public class PlayerV2(List<ICard> deckCards)
{
    public Deck Deck { get; } = new Deck(deckCards);
    public ShieldZone ShieldZone { get; } = new ShieldZone();
    public Hand Hand { get; } = new Hand();
    public ManaZone ManaZone { get; } = new ManaZone();
}