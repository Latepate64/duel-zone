using DuelMastersModels.Cards;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature AttackedCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; private set; }

        public BattleStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature, IBattleZoneCreature attackedCreature, IBattleZoneCreature blockingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
            BlockingCreature = blockingCreature;
        }

        public override IStep GetNextStep()
        {
            throw new System.NotImplementedException();
            //AttackDeclarationStep lastAttackDeclaration = Steps.Where(step => step is AttackDeclarationStep).Cast<AttackDeclarationStep>().Last();
            //BlockDeclarationStep lastBlockDeclaration = Steps.Where(step => step is BlockDeclarationStep).Cast<BlockDeclarationStep>().Last();

            //// 509.1. If the attacking creature was declared to attack the nonactive player and the attack was not redirected, the attack is considered a direct attack.
            //bool directAttack = lastAttackDeclaration.AttackedCreature == null && lastBlockDeclaration.BlockingCreature == null;
            //return new DirectAttackStep(ActivePlayer, lastAttackDeclaration.AttackingCreature, directAttack);
        }

        //TODO
        //public override IChoice PlayerActionRequired(IDuel duel)
        //{
        //    if (duel == null)
        //    {
        //        throw new ArgumentNullException(nameof(duel));
        //    }
        //    if (BlockingCreature != null)
        //    {
        //        duel.Battle(AttackingCreature, BlockingCreature);
        //    }
        //    else if (AttackedCreature != null)
        //    {
        //        duel.Battle(AttackingCreature, AttackedCreature);
        //    }
        //    return null;
        //}
    }
}
