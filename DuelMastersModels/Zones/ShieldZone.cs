using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    internal class ShieldZone : Zone<IShieldZoneCard>
    {
        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = true;

        internal override void Add(IZoneCard card, Duel duel)
        {
            _cards.Add(new ShieldZoneCard(card));
        }

        internal override void Remove(IShieldZoneCard card, Duel duel)
        {
            _cards.Remove(card);
        }
    }
}