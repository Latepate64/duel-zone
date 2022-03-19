using System.Linq;

namespace Engine.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main phase.
    /// </summary>
    public class MainPhase : PriorityPhase
    {
        public MainPhase() : base(Common.GameEvents.PhaseOrStep.Main)
        {
        }

        protected internal override bool PerformPriorityAction(IGame game)
        {
            var player = game.CurrentTurn.ActivePlayer;
            if (player != null)
            {
                var cards = player.GetCardsThatCanBePaidAndUsed(game);
                if (cards.Any())
                {
                    return player.ChooseCardToUse(game, cards);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public override Phase GetNextPhase(IGame game)
        {
            return new AttackPhase();
        }

        public MainPhase(MainPhase step) : base(step) { }

        public override Phase Copy()
        {
            return new MainPhase(this);
        }
    }
}
