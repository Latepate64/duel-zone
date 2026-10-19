using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class ForcedFrenzyContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    private readonly IPlayer _opponent;

    public ForcedFrenzyContinuousEffect(IPlayer opponent)
    {
        _opponent = opponent;
    }

    public ForcedFrenzyContinuousEffect(ForcedFrenzyContinuousEffect effect) : base(effect)
    {
        _opponent = effect._opponent;
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature.Owner == _opponent;
    }

    public override IContinuousEffect Copy()
    {
        return new ForcedFrenzyContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"Each of {_opponent}'s creatures attacks if able until the start of your next turn.";
    }
}
