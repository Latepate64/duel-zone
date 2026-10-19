using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class InfernalCommandContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    private readonly ICreature _creature;

    public InfernalCommandContinuousEffect(ICreature creature)
    {
        _creature = creature;
    }

    public InfernalCommandContinuousEffect(InfernalCommandContinuousEffect effect) : base(effect)
    {
        _creature = effect._creature;
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature == _creature;
    }

    public override IContinuousEffect Copy()
    {
        return new InfernalCommandContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{_creature} attacks if able until the start of your next turn.";
    }
}
