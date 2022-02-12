namespace Common.GameEvents
{
    public class AttackTargetRemovedEvent : GameEvent
    {
        public Card TargetCard { get; set; }
        public Player TargetPlayer { get; set; }

        public AttackTargetRemovedEvent()
        {
        }

        public override string ToString()
        {
            return $"{(TargetCard != null ? TargetCard : TargetPlayer)} is no longer being attacked.";
        }
    }
}
