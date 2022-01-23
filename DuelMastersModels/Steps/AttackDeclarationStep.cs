using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class AttackDeclarationStep : Step
    {
        internal Guid AttackTarget { get; set; }

        public AttackDeclarationStep(AttackPhase phase) : base(phase)
        {
        }

        public override void PerformTurnBasedAction(Game game)
        {
            var activePlayer = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            var attackers = game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer).Where(c => !c.Tapped && !c.AffectedBySummoningSickness(game) && GetPossibleAttackTargets(c, game).Any()).Distinct(new CardComparer());
            var attackersWithAttackTargets = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, game));
            var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
            var targets = options.SelectMany(x => x).SelectMany(x => x);
            if (targets.Any())
            {
                var dec = activePlayer.Choose(new AttackerChoice(game.CurrentTurn.ActivePlayer, options, attackers.Any(x => game.GetContinuousEffects<AttacksIfAbleEffect>(x).Any())));
                if (dec.Decision != null)
                {
                    var attacker = game.GetCard(dec.Decision.Item1);
                    attacker.Tapped = true;
                    var tapAbilities = attacker.Abilities.OfType<TapAbility>();
                    if (tapAbilities.Select(y => y.Id).Contains(dec.Decision.Item2))
                    {
                        Phase.PendingAbilities.AddRange(tapAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>());
                    }
                    else
                    {
                        Phase.SetAttackingCreature(attacker, game);
                        AttackTarget = dec.Decision.Item2;
                        game.Process(new CreatureAttackedEvent(new Card(attacker, true), game.GetAttackable(AttackTarget)));
                    }
                }
            }
        }

        private static IEnumerable<IAttackable> GetPossibleAttackTargets(Card attacker, Game game)
        {
            List<IAttackable> attackables = new List<IAttackable>();
            var opponent = game.GetOpponent(game.GetPlayer(attacker.Owner));
            if (opponent != null)
            {
                if (!game.GetContinuousEffects<CannotAttackPlayersEffect>(attacker).Any())
                {
                    attackables.Add(opponent);
                }
                if (!game.GetContinuousEffects<CannotAttackCreaturesEffect>(attacker).Any())
                {
                    var opponentsCreatures = game.BattleZone.GetCreatures(opponent.Id);
                    attackables.AddRange(opponentsCreatures.Where(c => c.Tapped).Distinct(new CardComparer()));
                    if (game.GetContinuousEffects<CanAttackUntappedCreaturesEffect>(attacker).Any())
                    {
                        attackables.AddRange(opponentsCreatures.Where(c => !c.Tapped).Distinct(new CardComparer()));
                    }
                }
                if (attackables.Any())
                {
                    attackables.AddRange(attacker.Abilities.OfType<TapAbility>());
                }
            }
            return attackables;
        }

        public override Step GetNextStep(Game game)
        {
            if (Phase.AttackingCreature != Guid.Empty)
            {
                var tapAbilities = game.GetCard(Phase.AttackingCreature).Abilities.OfType<TapAbility>();
                if (tapAbilities.Select(y => y.Id).Contains(AttackTarget))
                {
                    return new AttackDeclarationStep(Phase);
                }
                else
                {
                    return new BlockDeclarationStep(AttackTarget, Phase);
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
            AttackTarget = step.AttackTarget;
        }
    }
}
