namespace DuelMastersModels.GameEvents
{
    public class LoseEvent : GameEvent
    {
        public Player Player { get; }

        public LoseEvent(Player player)
        {
            Player = player;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} lost the game.";
        }
    }
}