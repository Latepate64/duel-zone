namespace Engine.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public Card Attacker { get; }
        public IAttackable Attackable { get; }

        public CreatureAttackedEvent(Card attacker, IAttackable attackable, Game game)
        {
            Attacker = attacker;
            Attackable = attackable;
            Text = Attackable is Card creature
                ? $"{game.GetOwner(Attacker)}'s {Attacker} attacked {game.GetOwner(creature)}'s {creature}."
                : $"{game.GetOwner(Attacker)}'s {Attacker} attacked {Attackable}.";
        }
    }
}
