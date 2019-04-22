using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions
{
    public class DeclareAttack : PlayerAction
    {
        public Collection<Creature> CreaturesThatCanAttack { get; private set; }

        public DeclareAttack(Player player, Collection<Creature> creaturesThatCanAttack) : base(player)
        {
            CreaturesThatCanAttack = creaturesThatCanAttack;
        }

        public override bool PerformAutomatically(Duel duel)
        {
            return false;
        }

        public void Declare(Duel duel, Creature attacker, Creature targetOfAttack)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            attacker.Tapped = true;
            var step = (duel.CurrentTurn.CurrentStep as Steps.AttackDeclarationStep);
            step.AttackingCreature = attacker;
            step.AttackedCreature = targetOfAttack;
        }
    }
}
