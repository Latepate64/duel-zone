using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// Liquid People can't be blocked.
/// </summary>
public sealed class KingNautilusEffect : ContinuousEffect, IUnblockableEffect
{
    public KingNautilusEffect() : base()
    {
    }

    public KingNautilusEffect(KingNautilusEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        return attacker.HasRace(Race.LiquidPeople);
    }

    public override IContinuousEffect Copy()
    {
        return new KingNautilusEffect(this);
    }
}
