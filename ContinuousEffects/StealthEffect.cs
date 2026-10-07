using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// Civilization stealth (This creature can't be blocked while your opponent has
/// any civilization cards in his mana zone.)
/// </summary>
public class StealthEffect : ContinuousEffect, IUnblockableEffect,
    ICivilizationable
{
    public StealthEffect(Civilization civilization) : base()
    {
        Civilization = civilization;
    }

    public StealthEffect(StealthEffect effect) : base(effect)
    {
        Civilization = effect.Civilization;
    }

    public Civilization Civilization { get; }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (!Applier.Opponent.ManaZone.HasAnyCivilizationCard(
            Civilization)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new StealthEffect(this);
    }
}
