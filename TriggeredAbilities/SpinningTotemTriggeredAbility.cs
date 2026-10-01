using Interfaces;

namespace TriggeredAbilities;

public sealed class SpinningTotemTriggeredAbility : LinkedTriggeredAbility
{
    private readonly ICreature _breaker;

    public SpinningTotemTriggeredAbility() : base()
    {
    }

    public SpinningTotemTriggeredAbility(ICreature breaker) : base()
    {
        _breaker = breaker;
    }

    public SpinningTotemTriggeredAbility(SpinningTotemTriggeredAbility ability) : base(ability)
    {
        _breaker = ability._breaker;
    }

    public override IAbility Copy()
    {
        return new SpinningTotemTriggeredAbility(this);
    }

    public override string ToString()
    {
        return "Whenever any of your nature creatures is attacking your opponent and becomes blocked, it breaks one of his shields.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override void Resolve(IGame game)
    {
        game.Break(_breaker, 1);
    }
}
