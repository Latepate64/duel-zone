using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of creatures player has selected.
    /// </summary>
    public class CreatureSelectionResponse<TCreature> : PlayerActionResponse where TCreature : ICreature
    {
        internal ReadOnlyCreatureCollection<TCreature> SelectedCreatures { get; }

        /// <summary>
        /// Creates a creature selection response from creature collection.
        /// </summary>
        /// <param name="selectedCreatures">Creatures player has selected.</param>
        public CreatureSelectionResponse(ReadOnlyCreatureCollection<TCreature> selectedCreatures)
        {
            SelectedCreatures = selectedCreatures;
        }

        /// <summary>
        /// Creates a creature selection response from creature.
        /// </summary>
        /// <param name="selectedCreature">Creature player has selected.</param>
        public CreatureSelectionResponse(TCreature selectedCreature)
        {
            SelectedCreatures = new ReadOnlyCreatureCollection<TCreature>(selectedCreature);
        }
    }
}
