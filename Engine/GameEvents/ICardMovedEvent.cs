using Common;
using System;

namespace Engine.GameEvents
{
    public interface ICardMovedEvent : IGameEvent
    {
        IPlayer Player { get; }
        Guid CardInSourceZone { get; }
        ZoneType Source { get; }
        ZoneType Destination { get; }
        bool EntersTapped { get; }
        ICard Card { get; set; }
    }
}
