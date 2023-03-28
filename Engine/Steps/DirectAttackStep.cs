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
            var attackingCreature = Phase.AttackingCreature;
            if (attackingCreature != null)
            {
                if (game.GetOpponent(attackingCreature.Owner).ShieldZone.HasCards)
                {
                    var breakAmount = GetAmountOfShieldsToBreak(game, attackingCreature);
                    game.Break(attackingCreature, breakAmount);
                }
                else
                {
                    game.GetOpponent(attackingCreature.Owner).DirectlyAttacked = true;
                }
            }
        }

        private static int GetAmountOfShieldsToBreak(IGame game, ICard attackingCreature)
        {
            return game.GetAmountOfShieldsCreatureBreaks(attackingCreature) + game.ContinuousEffects.GetAmountOfShieldsCreatureBreaksAdditionally(attackingCreature);
        }

        public override IStep Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}
