using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;


/// <summary>
/// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
/// </summary>
public class Hand : Zone, IHand
{
    public Hand(params ICard[] cards) : base(ZoneType.Hand, cards)
    {
    }

    public Hand(Zone zone) : base(zone)
    {
    }

    public override IZone Copy()
    {
        return new Hand(this);
    }
}
