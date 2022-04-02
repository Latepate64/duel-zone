using System;

namespace Common.GameEvents
{
    public interface ICardMovedEvent : ICardEvent
    {
        Guid CardInSourceZone { get; set; }
        ZoneType Destination { get; set; }
        IPlayer Player { get; set; }
        ZoneType Source { get; set; }
        bool EntersTapped { get; set; }

        string ToString();
    }
}