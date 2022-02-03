using System;

namespace Common.GameEvents
{
    public class AbilityTriggeredEvent : GameEvent
    {
        public Guid Ability { get; }

        public AbilityTriggeredEvent(Guid ability)
        {
            Ability = ability;
        }

        public override string ToString()
        {
            return $"{Ability} triggered.";//, {Ability.OneShotEffect} is waiting to be resolved.";
        }
    }
}
