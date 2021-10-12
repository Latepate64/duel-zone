using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : TurnBasedActionStep
    {
        internal Guid AttackingCreature { get; set; }
        internal Guid AttackTarget { get; set; }

        public AttackDeclarationStep()
        {
        }

        public override Choice PerformTurnBasedAction(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var attackers = duel.GetPlayer(duel.CurrentTurn.ActivePlayer).BattleZone.Creatures.Where(c => !c.Tapped && !c.AffectedBySummoningSickness(duel)).Distinct(new PermanentComparer());
                var attackersWithAttackTargets = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, duel));
                var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
                var targets = options.SelectMany(x => x).SelectMany(x => x);
                if (targets.Any())
                {
                    return new AttackerChoice(duel.CurrentTurn.ActivePlayer, options, attackers.Any(x => duel.GetContinuousEffects<AttacksIfAbleEffect>(x).Any()));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var attackerChoice = decision as AttackerDecision;
                if (attackerChoice.Decision != null)
                {
                    AttackingCreature = attackerChoice.Decision.Item1;
                    AttackTarget = attackerChoice.Decision.Item2;
                    var attacker = duel.GetPermanent(AttackingCreature);
                    attacker.Tapped = true;
                    var tapAbilities = attacker.Abilities.OfType<TapAbility>();
                    if (tapAbilities.Select(y => y.Id).Contains(AttackTarget))
                    {
                        PendingAbilities.AddRange(tapAbilities);
                    }
                    else
                    {
                        duel.Trigger(new CreatureAttackedEvent(AttackingCreature));
                    }
                }
                return null;
            }
        }

        private static IEnumerable<IAttackable> GetPossibleAttackTargets(Permanent attacker, Duel duel)
        {
            List<IAttackable> attackables = new List<IAttackable>();
            var opponent = duel.GetOpponent(duel.GetPlayer(attacker.Controller));
            if (!duel.GetContinuousEffects<CannotAttackPlayersEffect>(attacker).Any())
            {
                attackables.Add(opponent);
            }
            if (!duel.GetContinuousEffects<CannotAttackCreaturesEffect>(attacker).Any())
            {
                attackables.AddRange(opponent.BattleZone.Creatures.Where(c => c.Tapped).Distinct(new PermanentComparer()));
            }
            if (attackables.Any())
            {
                attackables.AddRange(attacker.Abilities.OfType<TapAbility>());
            }
            return attackables;
        }

        public override Step GetNextStep(Duel duel)
        {
            if (AttackingCreature != Guid.Empty)
            {
                var tapAbilities = duel.GetPermanent(AttackingCreature).Abilities.OfType<TapAbility>();
                if (tapAbilities.Select(y => y.Id).Contains(AttackTarget))
                {
                    return new AttackDeclarationStep();
                }
                else
                {
                    return new BlockDeclarationStep(AttackingCreature, AttackTarget);
                }
            }
            // 506.2. If an attacking creature is not specified, the other substeps are skipped.
            else
            {
                return new EndOfTurnStep();
            }
        }

        public override Step Copy()
        {
            return new AttackDeclarationStep(this);
        }

        public AttackDeclarationStep(AttackDeclarationStep step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
            AttackTarget = step.AttackTarget;
        }
    }
}
