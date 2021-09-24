using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : TurnBasedActionStep
    {
        internal Guid AttackingCreature { get; private set; }
        internal Guid TargetCreature { get; private set; }

        public BattleStep(Guid attackingCreature, Guid targetCreature)
        {
            AttackingCreature = attackingCreature;
            TargetCreature = targetCreature;
        }

        public override Step GetNextStep(Duel duel)
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
            return Copy(new BattleStep(AttackingCreature, TargetCreature));
        }

        public override Choice PerformTurnBasedAction(Duel duel, Choice choice)
        {
            duel.Battle(AttackingCreature, TargetCreature);
            return null;
        }
    }
}
