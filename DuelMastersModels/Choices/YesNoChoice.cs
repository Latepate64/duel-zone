namespace DuelMastersModels.Choices
{
    public class YesNoChoice : Choice
    {
        public bool Decision { get; set; }

        public YesNoChoice(System.Guid player) : base(player)
        {
        }
    }
}