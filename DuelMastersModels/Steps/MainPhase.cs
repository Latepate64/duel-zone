using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main phase.
    /// </summary>
    public class MainPhase : PriorityPhase
    {
        public MainPhase()
        {
        }

        protected internal override bool PerformPriorityAction(Game game)
        {
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            if (player != null)
            {
                var cards = player.GetUsableCards();
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

        public override Phase GetNextPhase(Game game)
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
