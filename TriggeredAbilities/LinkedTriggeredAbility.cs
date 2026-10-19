using Interfaces;

namespace TriggeredAbilities;

/// <summary>
/// Triggered ability whose effect is tightly coupled with the trigger condition.
/// </summary>
public abstract class LinkedTriggeredAbility : ITriggeredAbility
{
    protected LinkedTriggeredAbility()
    {
    }

    protected LinkedTriggeredAbility(LinkedTriggeredAbility ability)
    {
    }

    public ICard Source { get; set; }
    public IPlayer Controller { get; set; }

    public abstract bool CanTrigger(IGameEvent gameEvent, IGame game);
    public virtual bool CheckInterveningIfClause(IGame game)
    {
        return true;
    }
    public abstract IAbility Copy();
    public abstract void Resolve(IGame game);
    public abstract ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent);
}
