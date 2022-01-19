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

        public override void PerformTurnBasedAction(Game game)
        {
            var activePlayer = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            var attackers = activePlayer.BattleZone.Creatures.Where(c => !c.Tapped && !c.AffectedBySummoningSickness(game) && GetPossibleAttackTargets(c, game).Any()).Distinct(new CardComparer());
            var attackersWithAttackTargets = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, game));
            var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
            var targets = options.SelectMany(x => x).SelectMany(x => x);
            if (targets.Any())
            {
                var dec = activePlayer.Choose(new AttackerChoice(game.CurrentTurn.ActivePlayer, options, attackers.Any(x => game.GetContinuousEffects<AttacksIfAbleEffect>(x).Any())));
                if (dec.Decision != null)
                {
                    AttackingCreature = dec.Decision.Item1;
                    AttackTarget = dec.Decision.Item2;
                    var attacker = game.GetCard(AttackingCreature);
                    attacker.Tapped = true;
                    var tapAbilities = attacker.Abilities.OfType<TapAbility>();
                    if (tapAbilities.Select(y => y.Id).Contains(AttackTarget))
                    {
                        PendingAbilities.AddRange(tapAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>());
                    }
                    else
                    {
                        game.Process(new CreatureAttackedEvent(new Card(attacker, true), game.GetAttackable(AttackTarget)));
                    }
                }
            }
        }

        private static IEnumerable<IAttackable> GetPossibleAttackTargets(Card attacker, Game game)
        {
            List<IAttackable> attackables = new List<IAttackable>();
            var opponent = game.GetOpponent(game.GetPlayer(attacker.Owner));
            if (!game.GetContinuousEffects<CannotAttackPlayersEffect>(attacker).Any())
            {
                attackables.Add(opponent);
            }
            if (!game.GetContinuousEffects<CannotAttackCreaturesEffect>(attacker).Any())
            {
                attackables.AddRange(opponent.BattleZone.Creatures.Where(c => c.Tapped).Distinct(new CardComparer()));
                if (game.GetContinuousEffects<CanAttackUntappedCreaturesEffect>(attacker).Any())
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

        public override Step GetNextStep(Game game)
        {
            if (AttackingCreature != Guid.Empty)
            {
                var tapAbilities = game.GetCard(AttackingCreature).Abilities.OfType<TapAbility>();
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
