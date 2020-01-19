using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
    /// </summary>
    internal class Hand : Zone<IHandCard>
    {
        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = false;

        internal override void Add(IZoneCard card, Duel duel)
        {
            _cards.Add(new HandCard(card));
        }

        internal override void Remove(IHandCard card, Duel duel)
        {
            _cards.Remove(card);
        }
    }
}