using Common;
using System;

namespace Engine.GameEvents
{
    public class CardMovedEvent : GameEvent, ICardMovedEvent
    {
        public CardMovedEvent(IPlayer player, ZoneType source, ZoneType destination, Guid cardInSourceZone)
        {
            Player = player;
            Source = source;
            Destination = destination;
            CardInSourceZone = cardInSourceZone;
        }

        public IPlayer Player { get; }
        public Guid CardInSourceZone { get; }
        public ZoneType Source { get; }
        public ZoneType Destination { get; }
        public bool EntersTapped { get; }
        public ICard Card { get; set; }

        public override void Happen(IGame game)
        {
            if (Player != null)
            {
                var card = game.GetCard(CardInSourceZone);
                var removed = (Source == ZoneType.BattleZone ? game.BattleZone : game.GetPlayer(Player.Id).GetZone(Source)).Remove(card, game);
                foreach (var removedCard in removed)
                {
                    if (Destination != ZoneType.Anywhere)
                    {
                        // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
                        // 613.7d An object receives a timestamp at the time it enters a zone.
                        var newObject = new Card(removedCard, game.GetTimestamp());
                        if (EntersTapped)
                        {
                            newObject.Tapped = true;
                        }
                        try
                        {
                            (Destination == ZoneType.BattleZone ? game.BattleZone : game.GetPlayer(Player.Id).GetZone(Destination)).Add(newObject, game);
                            Card = newObject;
                        }
                        catch (PlayerNotInGameException) { }
                    }
                }
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
