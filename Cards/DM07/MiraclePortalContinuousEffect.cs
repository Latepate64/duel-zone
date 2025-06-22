using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM07;

public sealed class MiraclePortalContinuousEffect : UntilEndOfTurnEffect, IUnblockableEffect, IIgnoreCannotAttackPlayersEffects
{
    private readonly ICreature _creature;

    public MiraclePortalContinuousEffect(ICreature creature)
    {
        _creature = creature;
    }

    public MiraclePortalContinuousEffect(MiraclePortalContinuousEffect effect) : base(effect)
    {
        _creature = effect._creature;
    }

    public bool IgnoreCannotAttackPlayersEffects(ICreature attacker, IGame game)
    {
        return attacker == _creature;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return attacker == _creature;
    }

    public override IContinuousEffect Copy()
    {
        return new MiraclePortalContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{_creature} can't be blocked and ignore any effects that would prevent {_creature} from attacking your opponent.";
    }
}
