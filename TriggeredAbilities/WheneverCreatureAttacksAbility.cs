using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public abstract class WheneverCreatureAttacksAbility : CardTriggeredAbility
{
    protected WheneverCreatureAttacksAbility(WheneverCreatureAttacksAbility ability) : base(ability)
    {
    }

    protected WheneverCreatureAttacksAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CreatureAttackedEvent e && TriggersFrom(e.Attacker, game);
    }
}
