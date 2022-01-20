namespace DuelMastersModels.GameEvents
{
    public class ShieldTriggerEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public ShieldTriggerEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Game game)
        {
            return $"{Player} used shield trigger of {Card}.";
        }
    }
}
