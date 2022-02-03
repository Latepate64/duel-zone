using System;

namespace Common.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public Card Attacker { get; }
        public Guid Attackable { get; }

        public CreatureAttackedEvent(Card attacker, Guid attackable)
        {
            Attacker = attacker;
            Attackable = attackable;
            //Text = Attackable is Card creature
            //    ? $"{game.GetOwner(Attacker)}'s {Attacker} attacked {game.GetOwner(creature)}'s {creature}."
            //    : $"{game.GetOwner(Attacker)}'s {Attacker} attacked {Attackable}.";
        }
    }
}
