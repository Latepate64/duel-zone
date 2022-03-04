﻿namespace Common.GameEvents
{
    public class CreatureStoppedBlockingEvent : GameEvent
    {
        public Card Blocker { get; set; }

        public CreatureStoppedBlockingEvent()
        {
        }

        public override string ToString()
        {
            return $"{Blocker} is no longer blocking.";
        }
    }
}