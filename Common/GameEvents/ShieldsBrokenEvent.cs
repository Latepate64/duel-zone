namespace Common.GameEvents
{
    public class ShieldsBrokenEvent : GameEvent
    {
        public ShieldsBrokenEvent()
        {
        }

        public ICard Attacker { get; set; }
        public IPlayer Target { get; set; }
        public int Amount { get; set; }


        public override string ToString()
        {
            return $"{Attacker} broke {Amount} of {Target}'s shields.";
        }
    }
}
