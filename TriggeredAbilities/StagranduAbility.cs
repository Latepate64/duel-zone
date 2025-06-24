using GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class StagranduAbility : WheneverThisCreatureAttacksAbility
{
    public StagranduAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public StagranduAbility(StagranduAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e
            && e.Target is ICreature c && c.Power >= 6000;
    }
}
