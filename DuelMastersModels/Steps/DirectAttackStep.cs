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

        public override Step GetNextStep(Game game)
        {
            return new EndOfAttackStep();
        }

        public DirectAttackStep(DirectAttackStep step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }

        public override void PerformTurnBasedAction(Game game)
        {
            var attackingCreature = game.GetCard(AttackingCreature);
            var controller = game.GetPlayer(attackingCreature.Owner);
            var opponent = game.GetOpponent(controller);
            if (opponent.ShieldZone.Cards.Any())
            {
                int breakAmount = 1;
                if (game.GetContinuousEffects<DoubleBreakerEffect>(attackingCreature).Any())
                {
                    breakAmount = 2;
                }
                game.PutFromShieldZoneToHand(opponent.ShieldZone.Cards.Take(breakAmount), true);
                game.Process(new ShieldsBrokenEvent(new Card(attackingCreature, true), opponent.Copy(), breakAmount));
            }
            else
            {
                game.Process(new DirectAttackEvent(opponent.Copy()));
                game.Lose(opponent);
            }
        }

        public override Step Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}
