using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of creatures player has selected.
    /// </summary>
    public class CreatureSelectionResponse<TZoneCreature> : PlayerActionResponse where TZoneCreature : IZoneCreature
    {
        internal ReadOnlyCreatureCollection<TZoneCreature> SelectedCreatures { get; }

        /// <summary>
        /// Creates a creature selection response from creature collection.
        /// </summary>
        /// <param name="selectedCreatures">Creatures player has selected.</param>
        public CreatureSelectionResponse(ReadOnlyCreatureCollection<TZoneCreature> selectedCreatures)
        {
            SelectedCreatures = selectedCreatures;
        }

        /// <summary>
        /// Creates a creature selection response from creature.
        /// </summary>
        /// <param name="selectedCreature">Creature player has selected.</param>
        public CreatureSelectionResponse(TZoneCreature selectedCreature)
        {
            SelectedCreatures = new ReadOnlyCreatureCollection<TZoneCreature>(selectedCreature);
        }
    }
}
