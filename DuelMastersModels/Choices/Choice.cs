namespace DuelMastersModels.Choices
{
    /// <summary>
    /// Represents a choice a player can make.
    /// </summary>
    public abstract class Choice : IChoice
    {
        /// <summary>
        /// Player who makes the choice.
        /// </summary>
        public IPlayer Player { get; private set; }

        protected Choice(IPlayer player)
        {
            Player = player;
        }
    }
}