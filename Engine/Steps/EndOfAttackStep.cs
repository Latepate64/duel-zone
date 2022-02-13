namespace Engine.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep(AttackPhase phase) : base(phase, Common.GameEvents.PhaseOrStep.EndOfAttack)
        {
        }

        public override Step GetNextStep(Game game)
        {
            return new AttackDeclarationStep(Phase);
        }

        public override Step Copy()
        {
            return new EndOfAttackStep(this);
        }

        public override void PerformTurnBasedAction(Game game)
        {
            Phase.RemoveAttackingCreature(game);
            Phase.RemoveAttackTarget(game);
            Phase.RemoveBlockingCreature(game);
        }

        public EndOfAttackStep(EndOfAttackStep step) : base(step) { }
    }
}
