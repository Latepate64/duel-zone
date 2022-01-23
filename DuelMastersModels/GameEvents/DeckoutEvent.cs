namespace DuelMastersModels.GameEvents
{
    public class DeckoutEvent : GameEvent
    {
        public Player Player { get; }

        public DeckoutEvent(Player player)
        {
            Player = player;
        }

        public override string ToString()
        {
            return $"{Player}'s deck contains no cards.";
        }
    }
}
