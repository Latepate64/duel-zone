using System;

namespace Common.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public Card Attacker { get; set; }
        public Guid Attackable { get; set; }

        public CreatureAttackedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Attacker} attacked {Attackable}.";
        }
    }
}
