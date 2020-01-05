using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may select up to one creature.
    /// </summary>
    public abstract class OptionalCreatureSelection : CreatureSelection
    {
        internal OptionalCreatureSelection(Player player, ReadOnlyCreatureCollection creatures) : base(player, creatures)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Creatures.Count == 0 ? Perform(duel, null) : (this);
        }

        internal void Validate(Creature creature)
        {
            if (!(creature == null || Creatures.Contains(creature)))
            {
                throw new Exceptions.OptionalCreatureSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, Creature creature);
    }
}
