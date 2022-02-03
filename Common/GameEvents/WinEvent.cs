namespace Common.GameEvents
{
    public class WinEvent : GameEvent
    {
        public Player Player { get; }

        public WinEvent(Player player)
        {
            Player = player;
        }

        public override string ToString()
        {
            return $"{Player} won the game.";
        }
    }
}
