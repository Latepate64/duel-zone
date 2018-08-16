using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    public class DirectAttackStep : Step
    {
        public Creature AttackingCreature { get; private set; }

        public DirectAttackStep(Player activePlayer, Creature attackingCreature) : base(activePlayer, "Direct attack")
        {
            AttackingCreature = attackingCreature;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null; //TODO: Implement
        }
    }
}
