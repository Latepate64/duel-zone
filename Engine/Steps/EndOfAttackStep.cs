namespace Engine.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep(AttackPhase phase) : base(phase, Common.GameEvents.PhaseOrStep.EndOfAttack)
        {
        }

        public override IStep GetNextStep(IGame game)
        {
            return new AttackDeclarationStep(Phase);
        }

        public override IStep Copy()
        {
            return new EndOfAttackStep(this);
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            Phase.RemoveAttackingCreature(game);
            Phase.RemoveAttackTarget(game);
            Phase.RemoveBlockingCreature(game);
        }

        public EndOfAttackStep(EndOfAttackStep step) : base(step) { }
    }
}
