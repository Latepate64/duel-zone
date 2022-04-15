namespace Engine.Choices
{
    public abstract class Choice : IChoice
    {
        protected Choice(IPlayer maker, string description)
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
        public IPlayer Maker { get; }

        public abstract bool IsValid();
    }
}
