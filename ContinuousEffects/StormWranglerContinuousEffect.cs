using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class StormWranglerContinuousEffect : UntilEndOfTurnEffect, IBlocksIfAbleEffect, IUnblockableEffect
{
    private readonly ICreature _blocker;

    public StormWranglerContinuousEffect(ICreature blocker)
    {
        _blocker = blocker;
    }

    public StormWranglerContinuousEffect(StormWranglerContinuousEffect effect) : base(effect)
    {
        _blocker = effect._blocker;
    }

    public bool BlocksIfAble(ICreature blocker, ICreature attacker, IGame game)
    {
        return blocker == _blocker && IsSourceOfAbility(attacker);
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker) && blocker != _blocker;
    }

    public override IContinuousEffect Copy()
    {
        return new StormWranglerContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"This turn, {_blocker} blocks this creature if able and this creature can't be blocked by other creatures.";
    }
}
