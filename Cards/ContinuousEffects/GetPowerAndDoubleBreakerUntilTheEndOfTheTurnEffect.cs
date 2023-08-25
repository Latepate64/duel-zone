using Engine;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.ContinuousEffects
{
    abstract class GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect : GetPowerAndDoubleBreakerEffect, IExpirable
    {
        public GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect(GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect(int power) : base(power)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }
}
