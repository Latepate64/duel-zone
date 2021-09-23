namespace DuelMastersModels.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep()
        {
        }

        public override Step GetNextStep()
        {
            return new AttackDeclarationStep();
        }

        public override Step Copy()
        {
            return Copy(new EndOfAttackStep());
        }
    }
}
