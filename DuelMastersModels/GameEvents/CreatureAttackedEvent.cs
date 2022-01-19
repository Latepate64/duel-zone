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

        public override string ToString(Game game)
        {
            if (Attackable is Card creature)
            {
                return $"{game.GetOwner(Attacker)}'s {Attacker} attacked {game.GetOwner(creature)}'s {creature}.";
            }
            else
            {
                return $"{game.GetOwner(Attacker)}'s {Attacker} attacked {Attackable}.";
            }
        }
    }
}
