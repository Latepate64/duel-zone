using DuelMastersModels.Zones;
using System;

namespace DuelMastersModels.GameEvents
{
    public class CardMovedEvent : GameEvent
    {
        public Guid Player { get; }
        public Guid CardInSourceZone { get; }

        /// <summary>
        /// 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
        /// </summary>
        public Guid CardInDestinationZone { get; set; }
        public ZoneType Source { get; }
        public ZoneType Destination { get; set; }

        public CardMovedEvent(Guid player, Guid cardInSourceZone, ZoneType source, ZoneType destination) : base()
        {
            Player = player;
            CardInSourceZone = cardInSourceZone;
            Source = source;
            Destination = destination;
        }

        public CardMovedEvent(CardMovedEvent e) : base(e)
        {
            Player = e.Player;
            CardInSourceZone = e.CardInSourceZone;
            CardInDestinationZone = e.CardInDestinationZone;
            Source = e.Source;
            Destination = e.Destination;
        }

        public override string ToString(Game game)
        {
            return $"{Player} put {CardInSourceZone} from their {Source} into their {Destination}.";
        }

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Player);
            var card = game.GetCard(CardInSourceZone);
            (Source == ZoneType.BattleZone ? game.BattleZone : player.GetZone(Source)).Remove(card, game);

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(card, false);
            CardInDestinationZone = newObject.Id;
            (Destination == ZoneType.BattleZone ? game.BattleZone : player.GetZone(Destination)).Add(newObject, game);
        }

        public override GameEvent Copy()
        {
            return new CardMovedEvent(this);
        }
    }
}
