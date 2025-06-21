namespace Engine.Choices
{
    public interface INumberChoice : IChoice
    {
        int? Choice { get; set; }
    }

    public class NumberChoice : Choice, INumberChoice
    {
        public NumberChoice(NumberChoice choice) : base(choice)
        {
            Choice = choice.Choice;
        }

        public NumberChoice(IPlayer maker, string description) : base(maker, description)
        {
        }

        public int? Choice { get; set; }

        public override bool IsValid()
        {
            return Choice.HasValue && Choice >= 0;
        }
    }
}
