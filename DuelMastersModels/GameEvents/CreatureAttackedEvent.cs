namespace DuelMastersModels.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public Permanent Attacker { get; }
        public IAttackable Attackable { get; }

        public CreatureAttackedEvent(Permanent attacker, IAttackable attackable)
        {
            Attacker = attacker;
            Attackable = attackable;
        }

        public override string ToString(Duel duel)
        {
            if (Attackable is Permanent creature)
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
