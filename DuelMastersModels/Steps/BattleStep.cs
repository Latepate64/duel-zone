namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        public BattleStep(AttackPhase phase) : base(phase)
        {
        }

        public override Step GetNextStep(Game game)
        {
            return new EndOfAttackStep(Phase);
        }

        public BattleStep(BattleStep step) : base(step)
        {
        }

        public override void PerformTurnBasedAction(Game game)
        {
            game.Battle(Phase.AttackingCreature, Phase.BlockingCreature == System.Guid.Empty ? Phase.AttackTarget : Phase.BlockingCreature);
        }

        public override Step Copy()
        {
            return new BattleStep(this);
        }
    }
}
