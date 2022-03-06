using System;

namespace Common.GameEvents
{
    public class CreatureAttackedEvent : CardEvent
    {
        public Guid Attackable { get; set; }

        public CreatureAttackedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} attacked {Attackable}.";
        }
    }
}
