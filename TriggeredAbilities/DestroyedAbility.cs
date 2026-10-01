using Interfaces;

namespace TriggeredAbilities;

public abstract class DestroyedAbility : CardChangesZoneAbility
{
    protected DestroyedAbility(IOneShotEffect effect) : base(effect)
    {
    }

    protected DestroyedAbility(DestroyedAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
