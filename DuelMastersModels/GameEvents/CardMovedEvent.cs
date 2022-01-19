using DuelMastersModels.Zones;
using System;

namespace DuelMastersModels.GameEvents
{
    public class CardMovedEvent : GameEvent
    {
        public Guid Player { get; }
        public Guid Card { get; }
        public Guid NewObject { get; set; }
        public ZoneType Source { get; }
        public ZoneType Destination { get; set; }

        public CardMovedEvent(Guid player, Guid card, ZoneType source, ZoneType destination) : base()
        {
            Player = player;
            Card = card;
            Source = source;
            Destination = destination;
        }

        public CardMovedEvent(CardMovedEvent e) : base(e)
        {
            Player = e.Player;
            Card = e.Card;
            NewObject = e.NewObject;
            Source = e.Source;
            Destination = e.Destination;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their {Source} into their {Destination}.";
        }

        public override void Apply(Duel duel)
        {
            var player = duel.GetPlayer(Player);
            var sourceZone = player.GetZone(Source);
            var destinationZone = player.GetZone(Destination);
            var card = duel.GetCard(Card);
            sourceZone.Remove(card, duel);

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(card, false);
            NewObject = newObject.Id;
            destinationZone.Add(newObject, duel);
        }

        public override GameEvent Copy()
        {
            return new CardMovedEvent(this);
        }
    }
}
