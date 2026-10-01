using Interfaces;

namespace ContinuousEffects;

public abstract class UntilEndOfTurnEffect : ContinuousEffect, IExpirable
{
    protected UntilEndOfTurnEffect() : base()
    {
    }

    protected UntilEndOfTurnEffect(UntilEndOfTurnEffect effect) : base(effect)
    {
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
    }
}
