using Engine.GameEvents;
using Engine.Steps;

namespace Engine.Abilities
{
    /// <summary>
    /// Delayed triggered ability that reads "Whenever X happens this turn, Y happens.".
    /// </summary>
    public class WheneverSomethingHappensThisTurnAbility : DelayedTriggeredAbility, IExpirable
    {
        public WheneverSomethingHappensThisTurnAbility(ITriggeredAbility triggeredAbility, IAbility source) : base(triggeredAbility, source.Source, source.Controller, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }
}
