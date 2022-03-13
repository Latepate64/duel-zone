using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    public class Graveyard : Zone
    {
        public Graveyard() : base() { }

        public Graveyard(Zone zone) : base(zone)
        {
        }

        public override void Add(Card card, Game game)
        {
            card.KnownTo = game.Players.Select(x => x.Id).ToList();
            Cards.Add(card);
        }

        public override bool Remove(Card card, Game game)
        {
            return Cards.Remove(card);
        }

        public override string ToString()
        {
            return "graveyard";
        }
    }
}