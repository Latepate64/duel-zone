namespace Common.GameEvents
{
    public class AttackTargetRemovedEvent : GameEvent
    {
        public ICard TargetCard { get; set; }
        public IPlayer TargetPlayer { get; set; }

        public AttackTargetRemovedEvent()
        {
        }

        public override string ToString()
        {
            return $"{(TargetCard != null ? TargetCard : TargetPlayer)} is no longer being attacked.";
        }
    }
}
