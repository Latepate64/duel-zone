namespace Common.GameEvents
{
    public class BlockEvent : GameEvent
    {
        public Card Attacker { get; }
        public Card Blocker { get; }

        public BlockEvent(Card attacker, Card blocker)
        {
            Attacker = attacker;
            Blocker = blocker;
            //Text = $"{game.GetOwner(Blocker)}'s {Blocker} blocked {game.GetOwner(Attacker)}'s {Attacker}.";
        }
    }
}
