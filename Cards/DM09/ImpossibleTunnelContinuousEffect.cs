using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM09;

public class ImpossibleTunnelContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
{
    private readonly Race _race;

    public ImpossibleTunnelContinuousEffect(ImpossibleTunnelContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public ImpossibleTunnelContinuousEffect(Race race) : base()
    {
        _race = race;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return game.BattleZone.GetCreatures(_race).Contains(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new ImpossibleTunnelContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{_race}s can't be blocked this turn.";
    }
}
