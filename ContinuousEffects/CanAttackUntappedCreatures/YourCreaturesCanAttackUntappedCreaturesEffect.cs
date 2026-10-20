using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CanAttackUntappedCreatures;

public sealed class YourCreaturesCanAttackUntappedCreaturesEffect : ContinuousEffect,
    ICanAttackUntappedCreaturesEffect
{
    public YourCreaturesCanAttackUntappedCreaturesEffect() : base()
    {
    }

    public YourCreaturesCanAttackUntappedCreaturesEffect(
        YourCreaturesCanAttackUntappedCreaturesEffect effect) : base(effect)
    {
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return Applier.Equals(attacker.OwnerV2);
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesCanAttackUntappedCreaturesEffect(this);
    }
}
