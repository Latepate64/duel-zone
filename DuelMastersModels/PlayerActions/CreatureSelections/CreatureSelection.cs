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

        internal int MinimumSelection { get; private set; }

        internal int MaximumSelection { get; private set; }

        internal CreatureSelection(Player player, int minimumSelection, int maximumSelection, ReadOnlyCreatureCollection creatures) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Creatures = creatures;
        }
    }
}
