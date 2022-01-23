using System;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        internal Guid TargetCreature { get; private set; }

        public BattleStep(Guid targetCreature, AttackPhase phase) : base(phase)
        {
            TargetCreature = targetCreature;
        }

        public override Step GetNextStep(Game game)
        {
            return new EndOfAttackStep(Phase);
            //AttackDeclarationStep lastAttackDeclaration = Steps.Where(step => step is AttackDeclarationStep).Cast<AttackDeclarationStep>().Last();
            //BlockDeclarationStep lastBlockDeclaration = Steps.Where(step => step is BlockDeclarationStep).Cast<BlockDeclarationStep>().Last();

            //// 509.1. If the attacking creature was declared to attack the nonactive player and the attack was not redirected, the attack is considered a direct attack.
            //bool directAttack = lastAttackDeclaration.AttackedCreature == null && lastBlockDeclaration.BlockingCreature == null;
            //return new DirectAttackStep(ActivePlayer, lastAttackDeclaration.AttackingCreature, directAttack);
        }

        public BattleStep(BattleStep step) : base(step)
        {
            TargetCreature = step.TargetCreature;
        }

        public override void PerformTurnBasedAction(Game game)
        {
            game.Battle(Phase.AttackingCreature, TargetCreature);
        }

        public override Step Copy()
        {
            return new BattleStep(this);
        }
    }
}
