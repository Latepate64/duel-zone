namespace Common.GameEvents
{
    public class ShieldTriggerEvent : GameEvent
    {
        public Player Player { get; set; }
        public Card Card { get; set; }

        public ShieldTriggerEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} used shield trigger of {Card}.";
        }
    }
}
