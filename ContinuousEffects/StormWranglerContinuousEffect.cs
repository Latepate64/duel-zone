using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// This turn, that creature blocks this creature if able and this creature
/// can't be blocked by other creatures.
/// </summary>
public sealed class StormWranglerContinuousEffect : UntilEndOfTurnEffect,
    IBlocksIfAbleEffect, IUnblockableEffect
{
    private readonly ICreature _blocker;

    public StormWranglerContinuousEffect(ICreature blocker)
    {
        _blocker = blocker;
    }

    public StormWranglerContinuousEffect(
        StormWranglerContinuousEffect effect) : base(effect)
    {
        _blocker = effect._blocker;
    }

    public bool BlocksIfAble(ICreature blocker, ICreature attacker, IGame game)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (!blocker.Equals(_blocker)) return false;
        return true;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (blocker.Equals(_blocker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new StormWranglerContinuousEffect(this);
    }
}
