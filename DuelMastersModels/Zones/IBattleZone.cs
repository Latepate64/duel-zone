using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Zones
{
    public interface IBattleZone : IZone<IBattleZoneCard>
    {
        IEnumerable<IBattleZoneCreature> Creatures { get; }
        IEnumerable<IBattleZoneCreature> TappedCreatures { get; }
        IEnumerable<IBattleZoneCreature> UntappedCreatures { get; }
        IEnumerable<ITappable> TappedCards { get; }

        void UntapCards();
    }
}