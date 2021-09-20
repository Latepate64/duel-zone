using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : TurnBasedActionStep
    {
        internal Creature AttackingCreature { get; set; }
        internal Creature AttackedCreature { get; set; }

        public AttackDeclarationStep()
        {
        }

        public override Choice PerformTurnBasedAction(Duel duel)
        {
            // TODO: Check if there are creatures that can attack
            bool possibleToAttack = true;
            if (possibleToAttack)
            {
                return new AttackerChoice(duel.CurrentTurn.ActivePlayer);
            }
            else
            {
                return null;
            }
        }

        public override Step GetNextStep()
        {
            if (AttackingCreature != null)
            {
                return new BlockDeclarationStep(AttackingCreature, AttackedCreature);
            }
            // 506.2. If an attacking creature is not specified, the other substeps are skipped.
            else
            {
                return new EndOfTurnStep();
            }
        }

        public Choice DeclareAttackOnCreature(Creature attacker, Creature target, Duel duel)
        {
            AttackingCreature = attacker;
            AttackedCreature = target;
            return Proceed(null, duel);
        }

        public Choice DeclareAttackOnOpponent(Creature attacker, Duel duel)
        {
            AttackingCreature = attacker;
            return Proceed(null, duel);
        }

        //TODO
        //public override Choice PlayerActionRequired(Duel duel)
        //{
        //    if (AttackingCreature != null && !TargetOfAttackDeclared)
        //    {
        //        //TODO: If attacked creature is not null, check that it can be attacked.
        //        throw new System.NotImplementedException();
        //        //return new DeclareTargetOfAttack(ActivePlayer, duel.GetCreaturesThatCanBeAttacked(ActivePlayer));
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public Choice PerformTurnBasedActions(Duel duel)
        //{
        //    //IEnumerable<Creature> creatures = duel.GetCreaturesThatCanAttack(ActivePlayer);
        //    throw new System.NotImplementedException();
        //    //return creatures.Any()
        //    //    ? creatures.Any(creature => duel.AttacksIfAble(creature))
        //    //        ? new DeclareAttackerMandatory(ActivePlayer, creatures)
        //    //        : (Choice)new DeclareAttacker(ActivePlayer, creatures)
        //    //    : null;
        //}
    }
}
