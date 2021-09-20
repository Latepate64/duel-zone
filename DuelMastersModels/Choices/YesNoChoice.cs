namespace DuelMastersModels.Choices
{
    public class YesNoChoice : Choice
    {
        public bool Decision { get; set; }

        public YesNoChoice(Player player) : base(player)
        {
        }
    }
}