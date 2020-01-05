using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player selects creatures.
    /// </summary>
    public abstract class CreatureSelection : PlayerAction
    {
        /// <summary>
        /// Creatures player can select from.
        /// </summary>
        public ReadOnlyCreatureCollection Creatures { get; private set; }

        internal CreatureSelection(Player player, ReadOnlyCreatureCollection creatures) : base(player)
        {
            Creatures = creatures;
        }
    }
}
