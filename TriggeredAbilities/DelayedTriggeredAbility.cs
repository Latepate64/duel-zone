using Interfaces;

namespace TriggeredAbilities;

public abstract class DelayedTriggeredAbility : IDisposable, IDelayedTriggeredAbility
{
    internal ITriggeredAbility TriggeredAbility { get; private set; }

    public IDuration? Duration { get; }

    protected DelayedTriggeredAbility()
    {
    }

    protected DelayedTriggeredAbility(
        ITriggeredAbility triggeredAbility,
        ICard source,
        IPlayer owner,
        IDuration? duration)
    {
        TriggeredAbility = triggeredAbility;
        TriggeredAbility.Source = source;
        TriggeredAbility.Controller = owner;
        Duration = duration;
    }

    protected DelayedTriggeredAbility(DelayedTriggeredAbility ability)
    {
        TriggeredAbility = ability.TriggeredAbility.Copy() as ITriggeredAbility;
        Duration = ability.Duration?.Copy();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            //TODO: Make abilities disposable
            //TriggeredAbility.Dispose();
            TriggeredAbility = null;
        }
    }

    public abstract IDelayedTriggeredAbility Copy();
}
