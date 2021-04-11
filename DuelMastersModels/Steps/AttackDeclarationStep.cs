using DuelMastersModels.Cards;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    internal class AttackDeclarationStep : Step, ITurnBasedActionable
    {
        internal IBattleZoneCreature AttackingCreature { get; set; }
        internal IBattleZoneCreature AttackedCreature { get; set; }
        internal bool TargetOfAttackDeclared { get; set; }

        internal AttackDeclarationStep(IPlayer activePlayer) : base(activePlayer)
        {
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

        public IChoice PerformTurnBasedActions(IDuel duel)
        {
            //IEnumerable<IBattleZoneCreature> creatures = duel.GetCreaturesThatCanAttack(ActivePlayer);
            throw new System.NotImplementedException();
            //return creatures.Any()
            //    ? creatures.Any(creature => duel.AttacksIfAble(creature))
            //        ? new DeclareAttackerMandatory(ActivePlayer, creatures)
            //        : (Choice)new DeclareAttacker(ActivePlayer, creatures)
            //    : null;
        }
    }
}
