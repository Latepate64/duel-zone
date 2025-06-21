namespace Engine.Choices
{
    public class BooleanChoice : Choice, IBooleanChoice
    {
        public BooleanChoice(IBooleanChoice choice) : base(choice)
        {
            Choice = choice.Choice;
        }

        public BooleanChoice(IPlayer maker, string description) : base(maker, description)
        {
        }

        public bool? Choice { get; set; }

        public override bool IsValid()
        {
            return Choice.HasValue;
        }
    }
}
