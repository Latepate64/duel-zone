using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must select one creature.
    /// </summary>
    public abstract class MandatoryCreatureSelection<TZoneCreature> : CreatureSelection<TZoneCreature> where TZoneCreature : IZoneCreature
    {
        internal MandatoryCreatureSelection(Player player, ReadOnlyCreatureCollection<TZoneCreature> creatures) : base(player, creatures)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Creatures.Count == 1 ? Perform(duel, Creatures[0]) : (this);
        }

        internal void Validate(TZoneCreature creature)
        {
            if (!Creatures.Contains(creature))
            {
                throw new Exceptions.MandatoryCreatureSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, TZoneCreature creature);
    }
}