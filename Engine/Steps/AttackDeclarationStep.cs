using Engine.Abilities;
using Engine.Choices;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Steps
{
    public class AttackDeclarationStep : Step
    {
        public AttackDeclarationStep(AttackPhase phase) : base(phase)
        {
        }

        public override void PerformTurnBasedAction(Game game)
        {
            var activePlayer = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            var attackers = game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer).Where(c => !c.Tapped && !AffectedBySummoningSickness(game, c) && GetPossibleAttackTargets(c, game).Any());
            var attackersWithAttackTargets = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, game));
            var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
            var targets = options.SelectMany(x => x).SelectMany(x => x);
            if (targets.Any())
            {
                ChooseAttacker(game, activePlayer, attackers);
            }
        }

        internal static bool AffectedBySummoningSickness(Game game, Card creature)
        {
            return creature.SummoningSickness && !game.GetContinuousEffects<SpeedAttackerEffect>(creature).Any();
        }

        private void ChooseAttacker(Game game, Player activePlayer, IEnumerable<Card> attackers)
        {
            var minimum = attackers.Any(x => game.GetContinuousEffects<AttacksIfAbleEffect>(x).Any()) ? 1 : 0;
            var decision = activePlayer.Choose(new GuidSelection(activePlayer.Id, attackers, minimum, 1)).Decision;
            if (decision.Any())
            {
                ChooseAttackTarget(game, activePlayer, attackers, decision.Single());
            }
        }

        private void ChooseAttackTarget(Game game, Player activePlayer, IEnumerable<Card> attackers, Guid id)
        {
            var attacker = attackers.Single(x => x.Id == id);
            var possibleTargets = GetPossibleAttackTargets(attacker, game);
            IAttackable target = possibleTargets.Count() > 1
                ? game.GetAttackable(activePlayer.Choose(new GuidSelection(activePlayer.Id, possibleTargets.Select(x => x.Id), 1, 1)).Decision.Single())
                : possibleTargets.Single();
            attacker.Tapped = true;
            if (target.Id == attacker.Id)
            {
                Phase.PendingAbilities.AddRange(attacker.Abilities.OfType<TapAbility>().Select(x => x.Copy()).Cast<ResolvableAbility>());
            }
            else
            {
                Phase.SetAttackingCreature(attacker, game);
                Phase.AttackTarget = target.Id;
                game.Process(new CreatureAttackedEvent(new Card(attacker), game.GetAttackable(Phase.AttackTarget), game));
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
                    attackables.AddRange(opponentsCreatures.Where(c => c.Tapped));
                    if (game.GetContinuousEffects<CanAttackUntappedCreaturesEffect>(attacker).Any())
                    {
                        attackables.AddRange(opponentsCreatures.Where(c => !c.Tapped));
                    }
                    attackables.AddRange(opponentsCreatures.Where(creature => game.GetContinuousEffects<CanBeAttackedAsThoughTappedEffect>(creature).Any()));
                }
                if (attackables.Any() && attacker.Abilities.OfType<TapAbility>().Any())
                {
                    attackables.Add(attacker);
                }
            }
            return attackables;
        }

        public override Step GetNextStep(Game game)
        {
            if (Phase.AttackingCreature != Guid.Empty)
            {
                var tapAbilities = game.GetCard(Phase.AttackingCreature).Abilities.OfType<TapAbility>();
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

        public override Step Copy()
        {
            return new AttackDeclarationStep(this);
        }

        public AttackDeclarationStep(AttackDeclarationStep step) : base(step)
        {
        }
    }
}
