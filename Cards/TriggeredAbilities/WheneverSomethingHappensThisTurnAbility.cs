using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.TriggeredAbilities
{
    /// <summary>
    /// Delayed triggered ability that reads "Whenever X happens this turn, Y happens.".
    /// </summary>
    public class WheneverSomethingHappensThisTurnAbility : DelayedTriggeredAbility, IExpirable
    {
        public WheneverSomethingHappensThisTurnAbility(WheneverSomethingHappensThisTurnAbility ability) : base(ability)
        {
        }

        public WheneverSomethingHappensThisTurnAbility(ITriggeredAbility triggeredAbility, IAbility source) : base(triggeredAbility, source.Source, source.Controller, false)
        {
        }

        public override DelayedTriggeredAbility Copy()
        {
            return new WheneverSomethingHappensThisTurnAbility(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }
}
