namespace Engine.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone
    {
        public ShieldZone() : base() { }

        public ShieldZone(Zone zone) : base(zone)
        {
        }

        public override void Add(Card card, Game game)
        {
            Cards.Add(card);
        }

        public override bool Remove(Card card, Game game)
        {
            return Cards.Remove(card);
        }

        public override string ToString()
        {
            return "shield zone";
        }
    }
}