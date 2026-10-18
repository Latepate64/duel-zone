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
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WheneverThisCreatureBlocksAbility(this);
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card == Source;
    }
}
