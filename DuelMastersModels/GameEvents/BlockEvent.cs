namespace DuelMastersModels.GameEvents
{
    public class BlockEvent : GameEvent
    {
        public Card Attacker { get; }
        public Card Blocker { get; }

        public BlockEvent(Card attacker, Card blocker)
        {
            Attacker = attacker;
            Blocker = blocker;
        }

        public override string ToString(Duel duel)
        {
            return $"{duel.GetOwner(Blocker)}'s {Blocker} blocked {duel.GetOwner(Attacker)}'s {Attacker}.";
        }
    }
}
