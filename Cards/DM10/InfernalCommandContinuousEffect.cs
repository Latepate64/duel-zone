using ContinuousEffects;
using Engine;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10;

public class InfernalCommandContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
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

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
            && phase.Turn.ActivePlayer == Controller;
    }

    public override string ToString()
    {
        return $"{_creature} attacks if able until the start of your next turn.";
    }
}
