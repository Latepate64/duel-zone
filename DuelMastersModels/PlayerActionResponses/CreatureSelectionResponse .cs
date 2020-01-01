using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of creatures player has selected.
    /// </summary>
    public class CreatureSelectionResponse : PlayerActionResponse
    {
        internal ReadOnlyCreatureCollection SelectedCreatures { get; }

        /// <summary>
        /// Creates a creature selection response from creature collection.
        /// </summary>
        /// <param name="selectedCreatures">Creatures player has selected.</param>
        public CreatureSelectionResponse(ReadOnlyCreatureCollection selectedCreatures)
        {
            SelectedCreatures = selectedCreatures;
        }

        /// <summary>
        /// Creates a creature selection response from creature.
        /// </summary>
        /// <param name="selectedCreature">Creature player has selected.</param>
        public CreatureSelectionResponse(Creature selectedCreature)
        {
            SelectedCreatures = new ReadOnlyCreatureCollection(selectedCreature);
        }
    }
}
