using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : TurnBasedActionStep
    {
        internal IBattleZoneCreature AttackingCreature { get; set; }
        internal IBattleZoneCreature AttackedCreature { get; set; }
        internal bool TargetOfAttackDeclared { get; set; }

        public AttackDeclarationStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        public override IChoice PerformTurnBasedAction()
        {
            State = StepState.TurnBasedAction;
            throw new System.NotImplementedException();
        }

        public override IStep GetNextStep()
        {
            throw new System.NotImplementedException();
            //if (attackDeclarationStep.AttackingCreature != null)
            //{
            //    return new BlockDeclarationStep(ActivePlayer, attackDeclarationStep.AttackingCreature);
            //}
            //// 506.2. If an attacking creature is not specified, the other substeps are skipped.
            //else
            //{
            //    return new EndOfTurnStep(ActivePlayer);
            //}
        }

        //TODO
        //public override IChoice PlayerActionRequired(IDuel duel)
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

        //public IChoice PerformTurnBasedActions(IDuel duel)
        //{
        //    //IEnumerable<IBattleZoneCreature> creatures = duel.GetCreaturesThatCanAttack(ActivePlayer);
        //    throw new System.NotImplementedException();
        //    //return creatures.Any()
        //    //    ? creatures.Any(creature => duel.AttacksIfAble(creature))
        //    //        ? new DeclareAttackerMandatory(ActivePlayer, creatures)
        //    //        : (Choice)new DeclareAttacker(ActivePlayer, creatures)
        //    //    : null;
        //}
    }
}
