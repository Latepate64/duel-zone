using System.Linq;
using Interfaces;

namespace Engine.Steps
{
    public sealed class AttackDeclarationStep : Step
    {
        bool _tapAbilityUsed;

        public AttackDeclarationStep(AttackPhase phase) : base(phase, PhaseOrStep.AttackDeclaration)
        {
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            var attackers = game.GetCreaturesThatHaveAttackTargets();
            if (attackers.Any())
            {
                // _tapAbilityUsed = game.CurrentTurn.ActivePlayer.ChooseAttacker(game, attackers);
            }
        }

        public override Step GetNextStep(IGame game)
        {
            if (Phase.AttackingCreature != null)
            {
                if (_tapAbilityUsed)
                {
                    return new AttackDeclarationStep(Phase);
                }
                else
                {
                    return new BlockDeclarationStep(Phase);
                }
            }
            // 506.2. If an attacking creature is not specified, the other substeps are skipped.
            else
            {
                return null;
            }
        }

        public override Step Copy()
        {
            return new AttackDeclarationStep(this);
        }

        public AttackDeclarationStep(AttackDeclarationStep step) : base(step)
        {
        }
    }
}
