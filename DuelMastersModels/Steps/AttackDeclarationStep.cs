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

        public override Choice PerformTurnBasedAction(Duel duel, Choice choice)
        {
            if (choice == null)
            {
                var attackers = duel.GetPlayer(duel.CurrentTurn.ActivePlayer).BattleZone.Creatures.Where(c => !c.Tapped && !c.SummoningSickness);
                IEnumerable<IGrouping<Guid, IEnumerable<Guid>>> options = attackers.GroupBy(a => a.Id, a => GetPossibleAttackTargets(a, duel).Select(x => x.Id));
                if (options.Any())
                {
                    return new AttackerChoice(duel.CurrentTurn.ActivePlayer, options);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var attackerChoice = choice as AttackerChoice;
                if (attackerChoice.Selected != null)
                {
                    AttackingCreature = attackerChoice.Selected.Item1;
                    AttackTarget = attackerChoice.Selected.Item2;
                }
                return null;
            }
        }

        private static IEnumerable<IAttackable> GetPossibleAttackTargets(Creature attacker, Duel duel)
        {
            List<IAttackable> attackables = new List<IAttackable>();
            var opponent = duel.GetOpponent(duel.GetOwner(attacker));
            attackables.Add(opponent);
            attackables.AddRange(opponent.BattleZone.Creatures.Where(c => c.Tapped));
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
            return Copy(new AttackDeclarationStep
            {
                AttackingCreature = AttackingCreature,
                AttackTarget = AttackTarget,
            });
        }
    }
}
