namespace DuelMastersModels.GameEvents
{
    public class BlockEvent : GameEvent
    {
        public Permanent Attacker { get; }
        public Permanent Blocker { get; }

        public BlockEvent(Permanent attacker, Permanent blocker)
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
