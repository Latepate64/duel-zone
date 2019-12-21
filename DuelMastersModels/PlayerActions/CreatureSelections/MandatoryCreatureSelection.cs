using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public abstract class MandatoryCreatureSelection : CreatureSelection
    {
        protected MandatoryCreatureSelection(Player player, Collection<Creature> creatures) : base(player, 1, 1, creatures)
        { }

        public Creature SelectedCreature { get; set; }

        public override PlayerAction TryToPerformAutomatically(Duel duel)
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

        public bool Validate(Creature creature)
        {
            return Creatures.Contains(creature);
        }

        public abstract PlayerAction Perform(Duel duel, Creature creature);
    }
}