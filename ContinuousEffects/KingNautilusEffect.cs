using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class KingNautilusEffect : ContinuousEffect, IUnblockableEffect
{
    public KingNautilusEffect() : base()
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return attacker.HasRace(Race.LiquidPeople);
    }

    public override IContinuousEffect Copy()
    {
        return new KingNautilusEffect();
    }

    public override string ToString()
    {
        return "Liquid People can't be blocked.";
    }
}
