using Engine.GameEvents;
using System;

namespace Engine.Abilities
{
    public interface ITriggeredAbility : IResolvableAbility
    {
        bool CanTrigger(IGameEvent gameEvent);
        bool CheckInterveningIfClause();
        ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent);
    }
}