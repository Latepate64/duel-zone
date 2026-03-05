using Abilities;
using GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverThisCreatureBlocksAbility : CardTriggeredAbility
{
    public WheneverThisCreatureBlocksAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverThisCreatureBlocksAbility(WheneverThisCreatureBlocksAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is BecomeBlockedEvent e && TriggersFrom(e.Blocker, game);
    }

    public override Ability Copy()
    {
        return new WheneverThisCreatureBlocksAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever this creature blocks, {OneShotEffect}.";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card == Source;
    }
}
