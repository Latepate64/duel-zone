namespace DuelMastersModels.Choices
{
    public class YesNoChoice : Choice
    {
        public YesNoChoice(System.Guid player) : base(player)
        {
        }
    }

    public class YesNoDecision : Decision
    {
        public bool Decision { get; set; }

        public YesNoDecision(bool decision)
        {
            Decision = decision;
        }
    }
}