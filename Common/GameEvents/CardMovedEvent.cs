using System;

namespace Common.GameEvents
{
    public class CardMovedEvent : GameEvent
    {
        public Player Player { get; set; }
        public Guid CardInSourceZone { get; set; }

        /// <summary>
        /// 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
        /// </summary>
        public Card CardInDestinationZone { get; set; }
        public ZoneType Source { get; set; }
        public ZoneType Destination { get; set; }

        public CardMovedEvent() : base()
        {
            //if (game != null)
            //{
            //    Text = $"{game.GetPlayer(Player)} put {game.GetCard(CardInSourceZone)} from {ToString(Source)} into {ToString(Destination)}."; ;
            //}
        }

        private static string ToString(ZoneType zone)
        {
            switch (zone)
            {
                case ZoneType.BattleZone:
                    return "the battle zone";
                case ZoneType.Deck:
                    return "their deck";
                case ZoneType.Graveyard:
                    return "their graveyard";
                case ZoneType.Hand:
                    return "their hand";
                case ZoneType.ManaZone:
                    return "their mana zone";
                case ZoneType.ShieldZone:
                    return "their shields";
                case ZoneType.Anywhere:
                    return "anywhere";
                default:
                    throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            return $"{Player} put {CardInDestinationZone} from {ToString(Source)} into {ToString(Destination)}.";
        }

        public CardMovedEvent(CardMovedEvent e) : base(e)
        {
            Player = e.Player;
            CardInSourceZone = e.CardInSourceZone;
            CardInDestinationZone = e.CardInDestinationZone;
            Source = e.Source;
            Destination = e.Destination;
        }

        public override GameEvent Copy()
        {
            return new CardMovedEvent(this);
        }
    }
}
