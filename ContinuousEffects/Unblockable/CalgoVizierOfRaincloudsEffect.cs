using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// This creature can't be blocked by creatures that have power 4000 or more.
/// </summary>
public sealed class CalgoVizierOfRaincloudsEffect : ContinuousEffect,
    IUnblockableEffect
{
    public CalgoVizierOfRaincloudsEffect() : base()
    {
    }

    public CalgoVizierOfRaincloudsEffect(
        CalgoVizierOfRaincloudsEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (blocker.Power < 4000) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new CalgoVizierOfRaincloudsEffect(this);
    }
}
