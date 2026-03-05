using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class YourCreaturesCannotBeBlockedThisTurnEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
{
    public YourCreaturesCannotBeBlockedThisTurnEffect() : base()
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id).Contains(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesCannotBeBlockedThisTurnEffect();
    }

    public override string ToString()
    {
        return "Your creatures in the battle zone can't be blocked this turn.";
    }
}
