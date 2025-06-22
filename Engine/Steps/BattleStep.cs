using Interfaces;

namespace Engine.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public sealed class BattleStep : Step
    {
        public BattleStep(AttackPhase phase) : base(phase, PhaseOrStep.Battle)
        {
        }

        public override Step GetNextStep(IGame game)
        {
            return new EndOfAttackStep(Phase);
        }

        public BattleStep(BattleStep step) : base(step)
        {
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            if (Phase.AttackingCreature != null)
            {
                game.Battle(Phase.AttackingCreature, Phase.BlockingCreature == null ? Phase.AttackTarget as ICard : Phase.BlockingCreature);
            }
        }

        public override Step Copy()
        {
            return new BattleStep(this);
        }
    }
}
