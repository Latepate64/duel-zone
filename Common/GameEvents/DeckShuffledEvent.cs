﻿namespace Common.GameEvents
{
    public class DeckShuffledEvent : GameEvent
    {
        public Player Player { get; set; }

        public DeckShuffledEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} shuffled their deck.";
        }
    }
}