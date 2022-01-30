namespace Engine.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep(AttackPhase phase) : base(phase)
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
            Phase.AttackTarget = System.Guid.Empty;
            Phase.BlockingCreature = System.Guid.Empty;
        }

        public EndOfAttackStep(EndOfAttackStep step) : base(step) { }
    }
}
