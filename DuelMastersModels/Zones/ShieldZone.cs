using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone
    {
        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = true;

        internal ShieldZone(Player owner) : base(owner) { }

        internal override void Add(Card card, Duel duel)
        {
            _cards.Add(card);
        }

        internal override void Remove(Card card, Duel duel)
        {
            _cards.Remove(card);
        }
    }
}