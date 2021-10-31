using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class DirectAttackStep : AttackingCreatureStep
    {
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
                GameEvents.Enqueue(new DirectAttackEvent(new Player(opponent)));
                duel.Lose(opponent);
                return null;
            }
        }

        public override Step Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}
