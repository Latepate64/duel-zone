using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public abstract class CreatureSelection : PlayerAction
    {
        public Collection<Creature> Creatures { get; private set; }
        public Creature SelectedCreature { get; set; }

        protected CreatureSelection(Player player, Collection<Creature> creatures) : base(player)
        {
            Creatures = creatures;
        }
    }
}