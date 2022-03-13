namespace Common.GameEvents
{
    public class SpellCastEvent : CardMovedEvent
    {
        public SpellCastEvent() { }

        public SpellCastEvent(Player player, Card spell)
        {
            CardInSourceZone = spell.Id;
            Card = spell;
            Destination = ZoneType.Anywhere;
            Player = player;
            Source = ZoneType.Hand; // TODO: Possible to cast from elsewhere
        }

        public override string ToString()
        {
            return $"{Player} cast {Card}.";
        }
    }
}
