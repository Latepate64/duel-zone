using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;


/// <summary>
/// When a game begins, each player’s deck becomes their deck.
/// </summary>
public class Deck : Zone, IDeck
{
    public Deck(params ICard[] cards) : base(ZoneType.Deck, cards)
    {
    }

    public Deck(Deck zone) : base(zone)
    {
    }

    public IEnumerable<ICard> GetTopCards(int amount) => Cards.TakeLast(amount);

    public override IZone Copy()
    {
        return new Deck(this);
    }

    public ICard TopCard => GetTopCards(1).SingleOrDefault();
}
