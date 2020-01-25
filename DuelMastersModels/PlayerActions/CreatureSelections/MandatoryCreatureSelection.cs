using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must select one creature.
    /// </summary>
    public abstract class MandatoryCreatureSelection<TCreature> : CreatureSelection<TCreature> where TCreature : ICreature
    {
        internal MandatoryCreatureSelection(Player player, ReadOnlyCreatureCollection<TCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Creatures.Count == 1 ? Perform(duel, Creatures[0]) : (this);
        }

        internal void Validate(TCreature creature)
        {
            if (!Creatures.Contains(creature))
            {
                throw new Exceptions.MandatoryCreatureSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, TCreature creature);
    }
}