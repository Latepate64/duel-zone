using System;

namespace Common.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public Card Attacker { get; set; }
        public Guid Attackable { get; set; }

        public CreatureAttackedEvent()
        {
            //Text = Attackable is Card creature
            //    ? $"{game.GetOwner(Attacker)}'s {Attacker} attacked {game.GetOwner(creature)}'s {creature}."
            //    : $"{game.GetOwner(Attacker)}'s {Attacker} attacked {Attackable}.";
        }
    }
}
