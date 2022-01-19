namespace DuelMastersModels.GameEvents
{
    public class ShieldsBrokenEvent : GameEvent
    {
        public ShieldsBrokenEvent(Card attacker, Player target, int amount)
        {
            Attacker = attacker;
            Target = target;
            Amount = amount;
        }

        public Card Attacker { get; }
        public Player Target { get; }
        public int Amount { get; }


        public override string ToString(Game game)
        {
            return $"{Attacker} broke {Amount} of {Target}'s shields ({Target.ShieldZone.Cards.Count} remaining).";
        }
    }
}
