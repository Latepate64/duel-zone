namespace Common.GameEvents
{
    public class ShieldTriggerEvent : GameEvent
    {
        public IPlayer Player { get; set; }
        public ICard Card { get; set; }

        public ShieldTriggerEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} used shield trigger of {Card}.";
        }
    }
}
