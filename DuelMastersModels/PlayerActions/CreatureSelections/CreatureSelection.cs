using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player selects creatures.
    /// </summary>
    public abstract class CreatureSelection<TCreature> : PlayerAction where TCreature : ICreature
    {
        /// <summary>
        /// Creatures player can select from.
        /// </summary>
        public ReadOnlyCreatureCollection<TCreature> Creatures { get; private set; }

        internal CreatureSelection(Player player, ReadOnlyCreatureCollection<TCreature> creatures) : base(player)
        {
            Creatures = creatures;
        }
    }
}
