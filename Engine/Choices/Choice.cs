namespace Engine.Choices
{
    public abstract class Choice : IChoice
    {
        protected Choice(Player maker, string description)
        {
            Description = description;
            Maker = maker;
        }

        protected Choice(IChoice choice)
        {
            Description = choice.Description;
            Maker = choice.Maker;
        }

        public string Description { get; }
        public Player Maker { get; }

        public abstract bool IsValid();

        public override string ToString()
        {
            return Description;
        }
    }
}
