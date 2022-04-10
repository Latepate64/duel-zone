using Engine.Abilities;
using System;
using System.Linq;

namespace Engine.Steps
{
    public class AttackDeclarationStep : Step
    {
        public AttackDeclarationStep(AttackPhase phase) : base(phase, PhaseOrStep.AttackDeclaration)
        {
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            var attackers = game.GetCreaturesThatHaveAttackTargets();
            if (attackers.Any())
            {
                game.CurrentTurn.ActivePlayer.ChooseAttacker(game, attackers);
            }
        }

        public override IStep GetNextStep(IGame game)
        {
            if (Phase.AttackingCreature != Guid.Empty)
            {
                var tapAbilities = game.GetCard(Phase.AttackingCreature).GetAbilities<TapAbility>();
                if (tapAbilities.Select(y => y.Id).Contains(Phase.AttackTarget))
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

        public override IStep Copy()
        {
            return new AttackDeclarationStep(this);
        }

        public AttackDeclarationStep(AttackDeclarationStep step) : base(step)
        {
        }
    }
}
