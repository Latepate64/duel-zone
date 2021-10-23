namespace DuelMastersModels.GameEvents
{
    public class ShieldsBrokenEvent : GameEvent
    {
        public ShieldsBrokenEvent(Permanent attacker, Player target, int amount)
        {
            Attacker = attacker;
            Target = target;
            Amount = amount;
        }

        public Permanent Attacker { get; }
        public Player Target { get; }
        public int Amount { get; }


        public override string ToString(Duel duel)
        {
            return $"{Attacker} broke {Amount} of {Target}'s shields ({Target.ShieldZone.Cards.Count} remaining).";
        }
    }
}
