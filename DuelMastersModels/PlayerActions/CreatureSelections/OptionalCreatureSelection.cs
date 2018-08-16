using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public abstract class OptionalCreatureSelection : CreatureSelection
    {
        protected OptionalCreatureSelection(Player player, Collection<Creature> creatures) : base(player, creatures)
        { }

        public override bool SelectAutomatically()
        {
            return Creatures.Count == 0;
        }
    }
}
