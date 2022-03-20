namespace Common.GameEvents
{
    public class CreatureStoppedAttackingEvent : GameEvent
    {
        public ICard Attacker { get; set; }

        public CreatureStoppedAttackingEvent()
        {
        }

        public override string ToString()
        {
            return $"{Attacker} is no longer attacking.";
        }
    }
}
