using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player must select one creature.
    /// </summary>
    public abstract class MandatoryCreatureSelection : CreatureSelection
    {
        internal MandatoryCreatureSelection(Player player, ReadOnlyCreatureCollection creatures) : base(player, 1, 1, creatures)
        { }

        internal Creature SelectedCreature { get; set; }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Creatures.Count == 1)
            {
                SelectedCreature = Creatures[0];
                duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
                return Perform(duel, Creatures[0]);
            }
            else
            {
                return this;
            }
        }

        internal bool Validate(Creature creature)
        {
            return Creatures.Contains(creature);
        }

        internal abstract PlayerAction Perform(Duel duel, Creature creature);
    }
}