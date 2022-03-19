namespace Engine.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        public BattleStep(AttackPhase phase) : base(phase, Common.GameEvents.PhaseOrStep.Battle)
        {
        }

        public override IStep GetNextStep(IGame game)
        {
            return new EndOfAttackStep(Phase);
        }

        public BattleStep(BattleStep step) : base(step)
        {
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            game.Battle(Phase.AttackingCreature, Phase.BlockingCreature == System.Guid.Empty ? Phase.AttackTarget : Phase.BlockingCreature);
        }

        public override IStep Copy()
        {
            return new BattleStep(this);
        }
    }
}
