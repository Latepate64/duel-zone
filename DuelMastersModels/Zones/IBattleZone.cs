using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Zones
{
    public interface IBattleZone : IZone<IBattleZoneCard>
    {
        IEnumerable<IBattleZoneCreature> Creatures { get; }
        IEnumerable<ITappable> TappedCards { get; }

        IEnumerable<IBattleZoneCreature> GetTappedCreatures();
        IEnumerable<IBattleZoneCreature> GetTappedCreatures(IPlayer player);
        IEnumerable<IBattleZoneCreature> GetUntappedCreatures();
        IEnumerable<IBattleZoneCreature> GetUntappedCreatures(IPlayer player);
        void UntapCards();
    }
}