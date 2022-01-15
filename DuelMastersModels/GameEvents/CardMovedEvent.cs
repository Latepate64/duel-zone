using DuelMastersModels.Zones;

namespace DuelMastersModels.GameEvents
{
    public class CardMovedEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }
        public Zone Source { get; }
        public Zone Destination { get; }

        public CardMovedEvent(Player player, Card card, Zone source, Zone destination)
        {
            Player = new Player(player);
            Card = new Card(card, true);
            Source = source;
            Destination = destination;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their {Source} into their {Destination}.";
        }
    }
}
