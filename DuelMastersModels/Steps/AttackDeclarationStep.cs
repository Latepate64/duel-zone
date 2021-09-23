using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : TurnBasedActionStep
    {
        internal Creature AttackingCreature { get; set; }
        internal IAttackable AttackTarget { get; set; }

        public AttackDeclarationStep()
        {
        }

        public override Choice PerformTurnBasedAction(Duel duel, Choice choice)
        {
            if (choice == null)
            {
                var attackers = duel.BattleZone.Creatures.Where(c => c.Owner == duel.CurrentTurn.ActivePlayer && !c.Tapped && !c.SummoningSickness);
                IEnumerable<IGrouping<Creature, IEnumerable<IAttackable>>> options = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, duel));
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
            var opponent = attacker.Owner.Opponent;
            attackables.Add(opponent);
            attackables.AddRange(duel.BattleZone.Creatures.Where(c => c.Owner == opponent && c.Tapped));
            return attackables;
        }

        public override Step GetNextStep()
        {
            if (AttackingCreature != null)
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
                AttackingCreature = AttackingCreature.Copy() as Creature,
                AttackTarget = AttackTarget.Copy(),
            });
        }
    }
}
