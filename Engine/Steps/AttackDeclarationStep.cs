using Common.GameEvents;
using Engine.Abilities;
using Common.Choices;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
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
            var attackers = game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id).Where(c => !c.Tapped && !c.AffectedBySummoningSickness(game) && Player.GetPossibleAttackTargets(c, game).Any());
            var attackersWithAttackTargets = attackers.GroupBy(a => a, a => Player.GetPossibleAttackTargets(a, game));
            var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
            if (options.SelectMany(x => x).SelectMany(x => x).Any())
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
