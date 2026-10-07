using Interfaces;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public abstract class GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect : GetPowerAndDoubleBreakerEffect, IExpirable
{
    public GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect(GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect(int power) : base(power)
    {
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
    }
}
