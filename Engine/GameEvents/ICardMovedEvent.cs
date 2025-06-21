using Engine.Abilities;
using Interfaces;
using System;

namespace Engine.GameEvents
{
    public interface ICardMovedEvent : IGameEvent
    {
        Player Player { get; }
        Guid CardInSourceZone { get; }
        ZoneType Source { get; }
        ZoneType Destination { get; }
        bool EntersTapped { get; set; }
        Card CardInDestinationZone { get; set; }
        IAbility Ability { get; }
    }
}
