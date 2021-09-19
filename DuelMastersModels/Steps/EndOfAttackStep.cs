namespace DuelMastersModels.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        public override Step GetNextStep()
        {
            return new AttackDeclarationStep(ActivePlayer);
        }
    }
}
