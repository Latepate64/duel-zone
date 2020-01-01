using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may select up to one creature.
    /// </summary>
    public abstract class OptionalCreatureSelection : CreatureSelection
    {
        internal OptionalCreatureSelection(Player player, ReadOnlyCreatureCollection creatures) : base(player, 0, 1, creatures)
        { }

        internal Creature SelectedCreature { get; set; }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Creatures.Count == 0)
            {
                return Perform(duel, null);
            }
            else
            {
                return this;
            }
            //return Creatures.Count == 0;
        }

        internal bool Validate(Creature creature)
        {
            return creature == null || Creatures.Contains(creature);
        }

        internal abstract PlayerAction Perform(Duel duel, Creature creature);
    }
}
