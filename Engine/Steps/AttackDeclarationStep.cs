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
            var activePlayer = game.CurrentTurn.ActivePlayer;
            var attackers = game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id).Where(c => !c.Tapped && !AffectedBySummoningSickness(game, c) && GetPossibleAttackTargets(c, game).Any());
            var attackersWithAttackTargets = attackers.GroupBy(a => a, a => GetPossibleAttackTargets(a, game));
            var options = attackersWithAttackTargets.GroupBy(x => x.Key.Id, x => x.SelectMany(y => y.Select(z => z.Id)));
            var targets = options.SelectMany(x => x).SelectMany(x => x);
            if (targets.Any())
            {
                ChooseAttacker(game, activePlayer, attackers);
            }
        }

        internal static bool AffectedBySummoningSickness(IGame game, ICard creature)
        {
            return creature.SummoningSickness && (!game.GetContinuousEffects<SpeedAttackerEffect>(creature).Any() || !game.GetContinuousEffects<IgnoreCannotAttackPlayersEffects>(creature).Any());
        }

        private void ChooseAttacker(IGame game, IPlayer activePlayer, IEnumerable<ICard> attackers)
        {
            var minimum = attackers.Any(x => game.GetContinuousEffects<AttacksIfAbleEffect>(x).Any()) ? 1 : 0;
            var decision = activePlayer.Choose(new AttackerSelection(activePlayer.Id, attackers, minimum), game).Decision;
            if (decision.Any())
            {
                ChooseAttackTarget(game, activePlayer, attackers, decision.Single());
            }
        }

        private void ChooseAttackTarget(IGame game, IPlayer activePlayer, IEnumerable<ICard> attackers, Guid id)
        {
            var attacker = attackers.Single(x => x.Id == id);
            var possibleTargets = GetPossibleAttackTargets(attacker, game);
            Common.IIdentifiable target = possibleTargets.Count() > 1
                ? game.GetAttackable(activePlayer.Choose(new AttackTargetSelection(activePlayer.Id, possibleTargets.Select(x => x.Id), 1, 1), game).Decision.Single())
                : possibleTargets.Single();
            activePlayer.Tap(game, attacker);
            if (target.Id == attacker.Id)
            {
                Phase.PendingAbilities.AddRange(attacker.GetAbilities<TapAbility>().Select(x => x.Copy()).Cast<ResolvableAbility>());
            }
            else
            {
                Phase.SetAttackingCreature(attacker, game);
                Phase.AttackTarget = target.Id;
                game.Process(new CreatureAttackedEvent { Card = attacker.Convert(), Attackable = game.GetAttackable(Phase.AttackTarget).Id });
            }
        }

        private static IEnumerable<Common.IIdentifiable> GetPossibleAttackTargets(ICard attacker, IGame game)
        {
            List<Common.IIdentifiable> attackables = new();
            var opponent = game.GetOpponent(game.GetPlayer(attacker.Owner));
            if (opponent != null)
            {
                if (attacker.CanAttackPlayers(game))
                {
                    attackables.Add(opponent);
                }
                if (attacker.CanAttackCreatures(game))
                {
                    var opponentsCreatures = game.BattleZone.GetCreatures(opponent.Id);
                    attackables.AddRange(opponentsCreatures.Where(c => c.Tapped));
                    if (game.GetContinuousEffects<CanAttackUntappedCreaturesEffect>(attacker).Any())
                    {
                        attackables.AddRange(opponentsCreatures.Where(c => !c.Tapped));
                    }
                    attackables.AddRange(opponentsCreatures.Where(creature => game.GetContinuousEffects<CanBeAttackedAsThoughTappedEffect>(creature).Any()));
                }
                if (attackables.Any() && attacker.GetAbilities<TapAbility>().Any())
                {
                    attackables.Add(attacker);
                }
            }
            return attackables;
        }

        public override Step GetNextStep(IGame game)
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

        public override Step Copy()
        {
            return new AttackDeclarationStep(this);
        }

        public AttackDeclarationStep(AttackDeclarationStep step) : base(step)
        {
        }
    }
}
