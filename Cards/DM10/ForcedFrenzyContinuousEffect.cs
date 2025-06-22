using ContinuousEffects;
using Engine;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10;

public sealed class ForcedFrenzyContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
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

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
            && phase.Turn.ActivePlayer == Controller;
    }

    public override string ToString()
    {
        return $"Each of {_opponent}'s creatures attacks if able until the start of your next turn.";
    }
}
