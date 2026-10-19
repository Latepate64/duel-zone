using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CanAttackUntappedCreatures;

public class ThisCreatureCanAttackUntappedCreaturesEffect : ContinuousEffect,
    ICanAttackUntappedCreaturesEffect
{
    public ThisCreatureCanAttackUntappedCreaturesEffect() : base()
    {
    }

    private ThisCreatureCanAttackUntappedCreaturesEffect(
        ThisCreatureCanAttackUntappedCreaturesEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCanAttackUntappedCreaturesEffect(this);
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker);
    }
}
