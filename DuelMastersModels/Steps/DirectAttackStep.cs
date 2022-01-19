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

        public override void PerformTurnBasedAction(Duel duel)
        {
            var attackingCreature = duel.GetPermanent(AttackingCreature);
            var controller = duel.GetPlayer(attackingCreature.Owner);
            var opponent = duel.GetOpponent(controller);
            if (opponent.ShieldZone.Cards.Any())
            {
                int breakAmount = 1;
                if (duel.GetContinuousEffects<DoubleBreakerEffect>(attackingCreature).Any())
                {
                    breakAmount = 2;
                }
                duel.PutFromShieldZoneToHand(opponent.ShieldZone.Cards.Take(breakAmount), true);
                duel.Process(new ShieldsBrokenEvent(new Card(attackingCreature, true), opponent.Copy(), breakAmount));
            }
            else
            {
                //TODO: Direct attack victory should be checked as a state-based action instead.
                duel.Process(new DirectAttackEvent(opponent.Copy()));
                duel.Lose(opponent);
            }
        }

        public override Step Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}
