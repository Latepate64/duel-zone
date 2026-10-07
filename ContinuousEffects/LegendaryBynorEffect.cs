using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// Your other water creatures in the battle zone can't be blocked.
/// </summary>
public sealed class LegendaryBynorEffect : ContinuousEffect, IUnblockableEffect
{
    public LegendaryBynorEffect() : base()
    {
    }

    public LegendaryBynorEffect(LegendaryBynorEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (IsSourceOfAbility(attacker)) return false;
        if (attacker.OwnerV2.Equals(Applier)) return false;
        if (!attacker.HasCivilization(Civilization.Water)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new LegendaryBynorEffect(this);
    }
}
