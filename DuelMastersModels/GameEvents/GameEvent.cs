using DuelMastersModels.Zones;
using System;

namespace DuelMastersModels.GameEvents
{
    public abstract class GameEvent
    {
    }

    public class CardChangedZoneEvent : GameEvent
    {
        public Guid Card { get; }
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }

        public CardChangedZoneEvent(Guid card, ZoneType sourceZone, ZoneType destinationZone)
        {
            Card = card;
            SourceZone = sourceZone;
            DestinationZone = destinationZone;
        }
    }

    public class TurnEndsEvent : GameEvent
    {
        public Guid Turn { get; }

        public TurnEndsEvent(Guid turn)
        {
            Turn = turn;
        }
    }

    public class CreatureAttackedEvent : GameEvent
    {
        public Guid Attacker { get; }

        public CreatureAttackedEvent(Guid attacker)
        {
            Attacker = attacker;
        }
    }
}
