namespace DuelMastersModels.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public Card Attacker { get; }
        public IAttackable Attackable { get; }

        public CreatureAttackedEvent(Card attacker, IAttackable attackable)
        {
            Attacker = attacker;
            Attackable = attackable;
        }

        public override string ToString(Duel duel)
        {
            if (Attackable is Card creature)
            {
                return $"{duel.GetOwner(Attacker)}'s {Attacker} attacked {duel.GetOwner(creature)}'s {creature}.";
            }
            else
            {
                return $"{duel.GetOwner(Attacker)}'s {Attacker} attacked {Attackable}.";
            }
        }
    }
}
