using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// Creatures of that race can't be blocked this turn.
/// </summary>
public sealed class ImpossibleTunnelContinuousEffect : UntilEndOfTurnEffect,
    IUnblockableEffect
{
    private readonly Race _race;

    public ImpossibleTunnelContinuousEffect(
        ImpossibleTunnelContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public ImpossibleTunnelContinuousEffect(Race race) : base()
    {
        _race = race;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attacker.HasRace(_race)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ImpossibleTunnelContinuousEffect(this);
    }
}
