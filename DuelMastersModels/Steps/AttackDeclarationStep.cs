using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : AttackingCreatureStep
    {
        internal Guid AttackTarget { get; set; }

        public AttackDeclarationStep()
        {
        }

        public override void PerformTurnBasedAction(Duel duel)
        {
            var activePlayer = duel.GetPlayer(duel.CurrentTurn.ActivePlayer);
            var attackers = activePlayer.BattleZone.Creatures.Where(c => !c.Tapped && !c.AffectedBySummoningSickness(duel) && GetPossibleAttackTargets(c, duel).Any()).Distinct(new CardComparer());
            var attackersWithAttackTargets = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, duel));
            var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
            var targets = options.SelectMany(x => x).SelectMany(x => x);
            if (targets.Any())
            {
                var dec = activePlayer.Choose(new AttackerChoice(duel.CurrentTurn.ActivePlayer, options, attackers.Any(x => duel.GetContinuousEffects<AttacksIfAbleEffect>(x).Any())));
                if (dec.Decision != null)
                {
                    AttackingCreature = dec.Decision.Item1;
                    AttackTarget = dec.Decision.Item2;
                    var attacker = duel.GetPermanent(AttackingCreature);
                    attacker.Tapped = true;
                    var tapAbilities = attacker.Abilities.OfType<TapAbility>();
                    if (tapAbilities.Select(y => y.Id).Contains(AttackTarget))
                    {
                        PendingAbilities.AddRange(tapAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>());
                    }
                    else
                    {
                        duel.Trigger(new CreatureAttackedEvent(new Card(attacker, true), duel.GetAttackable(AttackTarget)));
                    }
                }
            }
        }

        private static IEnumerable<IAttackable> GetPossibleAttackTargets(Card attacker, Duel duel)
        {
            List<IAttackable> attackables = new List<IAttackable>();
            var opponent = duel.GetOpponent(duel.GetPlayer(attacker.Owner));
            if (!duel.GetContinuousEffects<CannotAttackPlayersEffect>(attacker).Any())
            {
                attackables.Add(opponent);
            }
            if (!duel.GetContinuousEffects<CannotAttackCreaturesEffect>(attacker).Any())
            {
                attackables.AddRange(opponent.BattleZone.Creatures.Where(c => c.Tapped).Distinct(new CardComparer()));
                if (duel.GetContinuousEffects<CanAttackUntappedCreaturesEffect>(attacker).Any())
                {
                    attackables.AddRange(opponent.BattleZone.Creatures.Where(c => !c.Tapped).Distinct(new CardComparer()));
                }
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
