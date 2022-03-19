using Common.GameEvents;
using System;

namespace Engine.Abilities
{
    public interface ITriggeredAbility : IResolvableAbility
    {
        bool CanTrigger(IGameEvent gameEvent, IGame game);
        bool CheckInterveningIfClause(IGame game);
        void Resolve(IGame game);
        ITriggeredAbility Trigger(Guid source, Guid owner);
    }
}