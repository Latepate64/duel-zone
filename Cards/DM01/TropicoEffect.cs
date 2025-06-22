using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM01;

public sealed class TropicoEffect : ContinuousEffect, IUnblockableEffect
{
    public TropicoEffect() : base()
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return attacker == Ability.Source && game.BattleZone.GetCreatures(Controller.Id).Count(
            x => x != Ability.Source) >= 2;
    }

    public override IContinuousEffect Copy()
    {
        return new TropicoEffect();
    }

    public override string ToString()
    {
        return "This creature can't be blocked while you have at least 2 other creatures in the battle zone.";
    }
}
