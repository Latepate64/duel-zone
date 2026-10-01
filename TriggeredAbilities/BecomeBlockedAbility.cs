using Interfaces;

namespace TriggeredAbilities;

public abstract class BecomeBlockedAbility : CardTriggeredAbility
{
    protected BecomeBlockedAbility(BecomeBlockedAbility ability) : base(ability)
    {
    }

    protected BecomeBlockedAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
