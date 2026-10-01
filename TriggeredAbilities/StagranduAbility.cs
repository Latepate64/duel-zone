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
        throw new NotImplementedException();
    }
}
