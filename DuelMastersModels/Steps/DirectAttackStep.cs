using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class DirectAttackStep : TurnBasedActionStep
    {
        public Guid AttackingCreature { get; private set; }

        public DirectAttackStep(Guid attackingCreature)
        {
            AttackingCreature = attackingCreature;
        }

        public override Step GetNextStep(Duel duel)
        {
            return new EndOfAttackStep();
        }

        public DirectAttackStep(DirectAttackStep step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }

        public override Choice PerformTurnBasedAction(Duel duel, Decision decision)
        {
            var attackingCreature = duel.GetPermanent(AttackingCreature);
            var controller = duel.GetPlayer(attackingCreature.Controller);
            var opponent = duel.GetOpponent(controller);
            if (opponent.ShieldZone.Cards.Any())
            {
                int breakAmount = 1;
                if (duel.GetContinuousEffects<DoubleBreakerEffect>(attackingCreature).Any())
                {
                    breakAmount = 2;
                }
                opponent.PutFromShieldZoneToHand(opponent.ShieldZone.Cards.Take(breakAmount), duel, true);
                GameEvents.Enqueue(new ShieldsBrokenEvent(new Permanent(attackingCreature), new Player(opponent), breakAmount));
                return null;
            }
            else
            {
                //TODO: Direct attack victory should be checked as a state-based action instead.
                var gameOver = new GameOver(WinReason.DirectAttack, new List<Guid> { controller.Id }, new List<Guid> { opponent.Id });
                duel.GameOverInformation = gameOver;
                return gameOver;
            }
        }

        public override Step Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}
