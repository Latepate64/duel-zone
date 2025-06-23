using Interfaces;
using System;

namespace Engine.Abilities;

/// <summary>
/// Triggered ability whose effect is tightly coupled with the trigger condition.
/// </summary>
public abstract class LinkedTriggeredAbility : Ability, ITriggeredAbility
{
    protected LinkedTriggeredAbility()
    {
    }

    protected LinkedTriggeredAbility(LinkedTriggeredAbility ability) : base(ability)
    {
    }

    public IOneShotEffect OneShotEffect { get; set; }

    public abstract bool CanTrigger(IGameEvent gameEvent, IGame game);

    public bool CheckInterveningIfClause(IGame game)
    {
        throw new NotImplementedException();
    }

    public abstract void Resolve(IGame game);

    public abstract ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent);
}
