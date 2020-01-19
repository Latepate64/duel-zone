using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player selects creatures.
    /// </summary>
    public abstract class CreatureSelection<TZoneCreature> : PlayerAction where TZoneCreature : IZoneCreature
    {
        /// <summary>
        /// Creatures player can select from.
        /// </summary>
        public ReadOnlyCreatureCollection<TZoneCreature> Creatures { get; private set; }

        internal CreatureSelection(Player player, ReadOnlyCreatureCollection<TZoneCreature> creatures) : base(player)
        {
            Creatures = creatures;
        }
    }
}
