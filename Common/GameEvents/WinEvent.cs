namespace Common.GameEvents
{
    public class WinEvent : GameEvent
    {
        public Player Player { get; set; }

        public WinEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} won the game.";
        }
    }
}
