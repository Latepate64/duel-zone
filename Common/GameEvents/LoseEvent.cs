namespace Common.GameEvents
{
    public class LoseEvent : GameEvent
    {
        public Player Player { get; set; }

        public LoseEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} lost the game.";
        }
    }
}