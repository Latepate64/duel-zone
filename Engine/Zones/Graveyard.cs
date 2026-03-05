using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;

/// <summary>
/// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
/// </summary>
public sealed class Graveyard : Zone, IGraveyard
{
    public Graveyard(params ICard[] cards) : base(ZoneType.Graveyard, cards) { }

    public Graveyard(Graveyard zone) : base(zone)
    {
    }

    public override IZone Copy()
    {
        return new Graveyard(this);
    }
}
