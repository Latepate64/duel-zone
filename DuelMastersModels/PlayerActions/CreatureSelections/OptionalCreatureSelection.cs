using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public abstract class OptionalCreatureSelection : CreatureSelection
    {
        protected OptionalCreatureSelection() { }

        protected OptionalCreatureSelection(Player player, Collection<Creature> creatures) : base(player, 0, 1, creatures)
        { }

        public Creature SelectedCreature { get; set; }

        public override bool PerformAutomatically(Duel duel)
        {
            return Creatures.Count == 0;
        }

        public bool Validate(Creature creature)
        {
            return creature == null || Creatures.Contains(creature);
        }

        public abstract void Perform(Duel duel, Creature creature);
    }
}
