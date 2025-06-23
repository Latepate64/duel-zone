using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class BattleshipMutantAbility : LinkedTriggeredAbility
{
    private readonly IEnumerable<ICreature> _cards;
    private readonly ICreature _toDestroy;

    public BattleshipMutantAbility(IEnumerable<ICreature> cards)
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
        return gameEvent is BattleEvent e && _cards.Any(x => x == e.AttackingCreature || x == e.DefendingCreature);
    }

    public override IAbility Copy()
    {
        return new BattleshipMutantAbility(this);
    }

    public override void Resolve(IGame game)
    {
        game.Destroy(this, _toDestroy);
    }

    public override string ToString()
    {
        return $"Whenever any of {_cards} battles, destroy it after the battle.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        var e = gameEvent as BattleEvent;
        var toDestroy = _cards.Single(x => x == e.AttackingCreature || x == e.DefendingCreature);
        return new BattleshipMutantAbility(toDestroy);
    }
}
