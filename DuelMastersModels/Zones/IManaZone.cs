using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Zones
{
    public interface IManaZone : IZone<IManaZoneCard>
    {
        IEnumerable<ITappable> TappedCards { get; }
        IEnumerable<IManaZoneCard> UntappedCards { get; }
        IEnumerable<IManaZoneCreature> NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone { get; }

        void UntapCards();
    }
}