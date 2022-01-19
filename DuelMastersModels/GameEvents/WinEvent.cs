namespace DuelMastersModels.GameEvents
{
    public class WinEvent : GameEvent
    {
        public Player Player { get; }

        public WinEvent(Player player)
        {
            Player = player;
        }

        public override string ToString(Game game)
        {
            return $"{Player} won the game.";
        }
    }
}
