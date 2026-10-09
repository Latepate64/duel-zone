using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// Your Cyber Lords or Hedrians can't be blocked.
/// </summary>
public sealed class HydroozeTheMutantEmperorUnblockableEffect :
    ContinuousEffect, IUnblockableEffect
{
    public HydroozeTheMutantEmperorUnblockableEffect() : base()
    {
    }

    public HydroozeTheMutantEmperorUnblockableEffect(
        HydroozeTheMutantEmperorUnblockableEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (attacker.OwnerV2 != Applier) return false;
        if (!attacker.HasRace(Race.CyberLord, Race.Hedrian)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new HydroozeTheMutantEmperorUnblockableEffect(this);
    }
}
