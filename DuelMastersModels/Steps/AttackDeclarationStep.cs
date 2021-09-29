using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
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
                var attackers = duel.GetPlayer(duel.CurrentTurn.ActivePlayer).BattleZone.Creatures.Where(c => !c.Tapped && !c.AffectedBySummoningSickness()).Distinct(new CardComparer());
                List<IGrouping<Guid, IEnumerable<Guid>>> options = attackers.GroupBy(a => a.Id, a => GetPossibleAttackTargets(a, duel).Select(x => x.Id)).ToList();
                if (options.Any())
                {
                    return new AttackerChoice(duel.CurrentTurn.ActivePlayer, options, attackers.SelectMany(x => x.Abilities).OfType<AttacksIfAbleAbility>().Any());
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
                    duel.GetCard(AttackingCreature).Tapped = true;
                    var attacker = duel.GetCard(AttackingCreature);
                    duel.CurrentTurn.CurrentStep.PendingAbilities.AddRange(attacker.Abilities.OfType<WheneverThisCreatureAttacksAbility>().Select(x => x.Copy()).Cast<NonStaticAbility>());
                }
                return null;
            }
        }

        private static IEnumerable<IAttackable> GetPossibleAttackTargets(Card attacker, Duel duel)
        {
            List<IAttackable> attackables = new List<IAttackable>();
            var opponent = duel.GetOpponent(duel.GetOwner(attacker));
            attackables.Add(opponent);
            attackables.AddRange(opponent.BattleZone.Creatures.Where(c => c.Tapped).Distinct(new CardComparer()));
            return attackables;
        }

        public override Step GetNextStep(Duel duel)
        {
            if (AttackingCreature != Guid.Empty)
            {
                return new BlockDeclarationStep(AttackingCreature, AttackTarget);
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
