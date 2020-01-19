using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    internal class Graveyard : Zone<IGraveyardCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal override void Add(IZoneCard card, Duel duel)
        {
            _cards.Add(new GraveyardCard(card));
        }

        internal override void Remove(IGraveyardCard card, Duel duel)
        {
            _cards.Remove(card);
        }
    }
}