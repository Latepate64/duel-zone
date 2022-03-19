﻿using System;

namespace Common.GameEvents
{
    public class CardMovedEvent : CardEvent
    {
        public IPlayer Player { get; set; }
        public Guid CardInSourceZone { get; set; }

        /// <summary>
        /// 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
        /// </summary>
        //public Card Card { get; set; }
        public ZoneType Source { get; set; }
        public ZoneType Destination { get; set; }

        public CardMovedEvent() : base()
        {
        }

        public static string ToString(ZoneType zone)
        {
            return zone switch
            {
                ZoneType.BattleZone => "the battle zone",
                ZoneType.Deck => "their deck",
                ZoneType.Graveyard => "their graveyard",
                ZoneType.Hand => "their hand",
                ZoneType.ManaZone => "their mana zone",
                ZoneType.ShieldZone => "their shields",
                ZoneType.Anywhere => "anywhere",
                _ => throw new InvalidOperationException(),
            };
        }

        public override string ToString()
        {
            return $"{Player} put {Card} from {ToString(Source)} into {ToString(Destination)}.";
        }

        public CardMovedEvent(CardMovedEvent e) : base(e)
        {
            if (e.Player != null)
            {
                Player = new Player(e.Player);
            }
            CardInSourceZone = e.CardInSourceZone;
            if (e.Card != null)
            {
                Card = new Card(e.Card, false);
            }
            Source = e.Source;
            Destination = e.Destination;
        }

        public override GameEvent Copy()
        {
            return new CardMovedEvent(this);
        }
    }
}
