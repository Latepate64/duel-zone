using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// This turn, it can't be blocked and you ignore any effects that would prevent
/// that creature from attacking your opponent.
/// </summary>
public sealed class MiraclePortalContinuousEffect : UntilEndOfTurnEffect,
    IUnblockableEffect, IIgnoreCannotAttackPlayersEffects
{
    private readonly ICreature _creature;

    public MiraclePortalContinuousEffect(ICreature creature)
    {
        _creature = creature;
    }

    public MiraclePortalContinuousEffect(
        MiraclePortalContinuousEffect effect) : base(effect)
    {
        _creature = (ICreature)effect._creature.Copy();
    }

    public bool IgnoreCannotAttackPlayersEffects(ICreature attacker, IGame game)
    {
        return attacker.Equals(_creature);
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        return attacker.Equals(_creature);
    }

    public override IContinuousEffect Copy()
    {
        return new MiraclePortalContinuousEffect(this);
    }
}
