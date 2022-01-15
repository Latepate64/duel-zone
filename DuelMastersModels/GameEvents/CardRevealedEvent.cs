﻿namespace DuelMastersModels.GameEvents
{
    public class CardRevealedEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardRevealedEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} revealed {Card} to their opponents.";
        }
    }
}