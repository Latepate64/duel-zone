using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities;

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
        return gameEvent is BecomeBlockedEvent e && TriggersFrom(e.Attacker, game);
    }
}
