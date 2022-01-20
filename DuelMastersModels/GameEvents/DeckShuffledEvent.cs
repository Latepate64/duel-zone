namespace DuelMastersModels.GameEvents
{
    public class DeckShuffledEvent : GameEvent
    {
        public Player Player { get; }

        public DeckShuffledEvent(Player player)
        {
            Player = player;
        }

        public override string ToString(Game game)
        {
            return $"{Player} shuffled their deck.";
        }
    }
}
