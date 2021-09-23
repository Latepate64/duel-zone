using DuelMastersModels.Cards;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        internal Creature AttackingCreature { get; private set; }
        internal Creature TargetCreature { get; private set; }

        public BattleStep(Creature attackingCreature, Creature targetCreature)
        {
            AttackingCreature = attackingCreature;
            TargetCreature = targetCreature;
        }

        public override Step GetNextStep()
        {
            return new EndOfAttackStep();
            //AttackDeclarationStep lastAttackDeclaration = Steps.Where(step => step is AttackDeclarationStep).Cast<AttackDeclarationStep>().Last();
            //BlockDeclarationStep lastBlockDeclaration = Steps.Where(step => step is BlockDeclarationStep).Cast<BlockDeclarationStep>().Last();

            //// 509.1. If the attacking creature was declared to attack the nonactive player and the attack was not redirected, the attack is considered a direct attack.
            //bool directAttack = lastAttackDeclaration.AttackedCreature == null && lastBlockDeclaration.BlockingCreature == null;
            //return new DirectAttackStep(ActivePlayer, lastAttackDeclaration.AttackingCreature, directAttack);
        }

        public override Step Copy()
        {
            return Copy(new BattleStep(AttackingCreature.Copy() as Creature, TargetCreature.Copy() as Creature));
        }

        //TODO
        //public override Choice PlayerActionRequired(Duel duel)
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
