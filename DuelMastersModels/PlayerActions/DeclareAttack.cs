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

        public bool Validate(Creature attackingCreature, Creature attackedCreature)
        {
            return CreaturesThatCanAttack.Contains(attackingCreature) && (attackedCreature == null || attackedCreature.Tapped);
            //TODO: If attacked creature is not null, check that it can be attacked.
        }

        public void Declare(Duel duel, Creature attacker, Creature targetOfAttack)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            attacker.Tapped = true;
            Steps.AttackDeclarationStep step = (duel.CurrentTurn.CurrentStep as Steps.AttackDeclarationStep);
            step.AttackingCreature = attacker;
            step.AttackedCreature = targetOfAttack;
        }
    }
}
