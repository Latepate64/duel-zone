using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// This creature can't be blocked by civilization creatures.
/// </summary>
public sealed class ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect :
    ContinuousEffect, IUnblockableEffect, ICivilizationable
{
    public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(
        ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect effect) :
            base(effect)
    {
        Civilization = effect.Civilization;
    }

    public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(
        Civilization civilization) : base()
    {
        Civilization = civilization;
    }

    public Civilization Civilization { get; }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (!blocker.HasCivilization(Civilization)) return false;
        return true;
    }

    public override ContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(
            this);
    }
}
