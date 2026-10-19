using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class YourLightCreaturesCannotBeBlockedThisTurnEffect :
    ContinuousEffect, IUnblockableEffect
{
    public YourLightCreaturesCannotBeBlockedThisTurnEffect() : base()
    {
    }

    public YourLightCreaturesCannotBeBlockedThisTurnEffect(
        YourLightCreaturesCannotBeBlockedThisTurnEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attacker.OwnerV2.Equals(Applier)) return false;
        if (!attacker.HasCivilization(Civilization.Light)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new YourLightCreaturesCannotBeBlockedThisTurnEffect(this);
    }
}
