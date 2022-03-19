namespace Common.GameEvents
{
    public class LoseEvent : GameEvent
    {
        public IPlayer Player { get; set; }

        public LoseEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} lost the game.";
        }
    }
}