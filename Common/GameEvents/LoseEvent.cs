namespace Common.GameEvents
{
    public class LoseEvent : GameEvent
    {
        public Player Player { get; }

        public LoseEvent(Player player)
        {
            Player = player;
        }

        public override string ToString()
        {
            return $"{Player} lost the game.";
        }
    }
}