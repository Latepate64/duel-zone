using Engine.Abilities;
using System;

namespace Engine.GameEvents
{
    public interface ICardMovedEvent : IGameEvent
    {
        IPlayer Player { get; }
        Guid CardInSourceZone { get; }
        ZoneType Source { get; }
        ZoneType Destination { get; }
        bool EntersTapped { get; set; }
        ICard CardInDestinationZone { get; set; }
        IAbility Ability { get; }
    }
}
