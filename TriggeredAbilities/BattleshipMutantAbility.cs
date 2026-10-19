using Interfaces;

namespace TriggeredAbilities;

/// <summary>
/// Whenever any of creatures battles, destroy it after the battle.
/// </summary>
public sealed class BattleshipMutantAbility : LinkedTriggeredAbility
{
    private readonly IEnumerable<ICreature> _cards;
    private readonly ICreature _toDestroy;

    public BattleshipMutantAbility(IEnumerable<ICreature> cards) : base()
    {
        _cards = cards;
    }

    public BattleshipMutantAbility(ICreature toDestroy)
    {
        _toDestroy = toDestroy;
    }

    public BattleshipMutantAbility(BattleshipMutantAbility ability) : base(ability)
    {
        _cards = ability._cards;
        _toDestroy = ability._toDestroy;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new BattleshipMutantAbility(this);
    }

    public override void Resolve(IGame game)
    {
        game.Destroy(this, _toDestroy);
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
    }
}
