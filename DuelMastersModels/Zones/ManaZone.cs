using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
    /// </summary>
    public class ManaZone : Zone<IManaZoneCard>//, ITappableZone// TappableZone<IManaZoneCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal IEnumerable<IManaZoneCard> TappedCards => new ReadOnlyCollection<IManaZoneCard>(Cards.Where(card => card.Tapped).ToList());
        internal IEnumerable<IManaZoneCard> UntappedCards => new ReadOnlyCollection<IManaZoneCard>(Cards.Where(card => !card.Tapped).ToList());

        internal IEnumerable<IManaZoneCreature> NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone => new ReadOnlyCollection<IManaZoneCreature>(Cards.OfType<IManaZoneCreature>().Where(c => c.Cost <= Cards.Count() && !(c is IEvolutionCreature)).ToList());

        internal void UntapCards()
        {
            foreach (ManaZoneCard card in TappedCards)
            {
                card.Tapped = false;
            }
        }

        internal override void Add(IManaZoneCard card, Duel duel)
        {
            _cards.Add(card);
        }

        internal override void Remove(IManaZoneCard card, Duel duel)
        {
            _ = _cards.Remove(card);
        }
    }
}