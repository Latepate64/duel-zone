using Common;
using System;

namespace Engine.GameEvents
{
    public class CardMovedEvent : GameEvent, ICardMovedEvent
    {
        public CardMovedEvent(IPlayer player, ZoneType source, ZoneType destination, Guid cardInSourceZone, bool tapped)
        {
            Player = player;
            Source = source;
            Destination = destination;
            CardInSourceZone = cardInSourceZone;
            EntersTapped = tapped;
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
                var removed = (Source == ZoneType.BattleZone ? game.BattleZone : Source == ZoneType.SpellStack ? game.SpellStack : game.GetPlayer(Player.Id).GetZone(Source)).Remove(card, game);
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
                ZoneType.SpellStack => "stack",
                _ => throw new InvalidOperationException(),
            };
        }

        public override string ToString()
        {
            return $"{Player} put {Card} from {ToString(Source)} into {ToString(Destination)}.";
        }
    }
}
