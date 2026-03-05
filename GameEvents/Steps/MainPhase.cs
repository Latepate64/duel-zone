using Interfaces;

namespace GameEvents.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main phase.
    /// </summary>
    public sealed class MainPhase : PriorityPhase
    {
        public MainPhase() : base(PhaseOrStep.Main)
        {
        }

        protected internal override bool PerformPriorityAction(IGame game)
        {
            throw new NotImplementedException();
        }

        public override Phase GetNextPhase(IGame game)
        {
            return new AttackPhase();
        }

        public MainPhase(MainPhase step) : base(step) { }

        public override Phase Copy()
        {
            return new MainPhase(this);
        }
    }
}
