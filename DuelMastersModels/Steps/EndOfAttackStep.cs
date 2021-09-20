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
    }
}
