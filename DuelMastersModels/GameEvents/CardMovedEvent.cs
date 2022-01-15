using DuelMastersModels.Zones;
using System;

namespace DuelMastersModels.GameEvents
{
    public class CardMovedEvent : GameEvent
    {
        public Guid Player { get; }
        public Card Card { get; }
        public ZoneType Source { get; }
        public ZoneType Destination { get; }

        public CardMovedEvent(Guid player, Card card, ZoneType source, ZoneType destination)
        {
            Player = player;
            if (card != null)
            {
                Card = new Card(card, true);
            }
            Source = source;
            Destination = destination;
        }

        public CardMovedEvent(CardMovedEvent e)
        {
            Player = e.Player;
            Card = e.Card.Copy();
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

            sourceZone.Remove(Card);

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(Card, false);
            _ = destinationZone.Add(newObject, duel, sourceZone);
        }

        public override GameEvent Copy()
        {
            return new CardMovedEvent(this);
        }
    }
}
