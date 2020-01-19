using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
    /// </summary>
    internal class ManaZone : Zone<IManaZoneCard>, ITappableZone// TappableZone<IManaZoneCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal ReadOnlyCardCollection<IManaZoneCard> TappedCards => new ReadOnlyCardCollection<IManaZoneCard>(Cards.Where(card => card.Tapped));
        internal ReadOnlyCardCollection<IManaZoneCard> UntappedCards => new ReadOnlyCardCollection<IManaZoneCard>(Cards.Where(card => !card.Tapped));

        public void UntapCards()
        {
            foreach (ManaZoneCard card in TappedCards)
            {
                card.Tapped = false;
            }
        }

        internal override void Add(IZoneCard card, Duel duel)
        {
            ManaZoneCard manaZoneCard = new ManaZoneCard(card);
            if (manaZoneCard.Civilizations.Count > 1)
            {
                manaZoneCard.Tapped = true;
            }
            _cards.Add(manaZoneCard);
        }

        internal override void Remove(IManaZoneCard card, Duel duel)
        {
            _cards.Remove(card);
        }
    }
}