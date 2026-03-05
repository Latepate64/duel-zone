using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SpinalParasiteContinuousEffect : UntilEndOfTurnEffect, IAttacksIfAbleEffect
{
    private readonly ICreature _creature;

    public SpinalParasiteContinuousEffect(ICreature creature)
    {
        _creature = creature;
    }

    public SpinalParasiteContinuousEffect(SpinalParasiteContinuousEffect effect) : base(effect)
    {
        _creature = effect._creature;
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature == _creature;
    }

    public override IContinuousEffect Copy()
    {
        return new SpinalParasiteContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{_creature} attacks this turn if able.";
    }
}
