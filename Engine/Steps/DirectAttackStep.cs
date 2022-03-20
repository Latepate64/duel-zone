using Common.GameEvents;
using Engine.ContinuousEffects;
using System.Linq;

namespace Engine.Steps
{
    public class DirectAttackStep : Step
    {
        public DirectAttackStep(AttackPhase phase) : base(phase, PhaseOrStep.DirectAttack)
        {
        }

        public override IStep GetNextStep(IGame game)
        {
            return new EndOfAttackStep(Phase);
        }

        public DirectAttackStep(DirectAttackStep step) : base(step)
        {
        }

        public override void PerformTurnBasedAction(IGame game)
        {
            var attackingCreature = game.GetCard(Phase.AttackingCreature);
            var controller = game.GetPlayer(attackingCreature.Owner);
            var opponent = game.GetOpponent(controller);
            if (opponent.ShieldZone.Cards.Any())
            {
                int breakAmount = 1;
                var breakerEffects = game.GetContinuousEffects<BreakerEffect>(attackingCreature);
                if (breakerEffects.Any())
                {
                    breakAmount = breakerEffects.Max(x => x.GetAmount());
                }
                game.PutFromShieldZoneToHand(opponent.ShieldZone.Cards.Take(breakAmount), true);
                game.Process(new ShieldsBrokenEvent { Attacker = attackingCreature.Convert(), Target = opponent.Copy(), Amount = breakAmount });
            }
            else
            {
                game.Process(new DirectAttackEvent { Player = opponent.Copy() });
                game.Lose(opponent);
            }
        }

        public override IStep Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}
