using DuelMastersModels.Choices;
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
                var usableCards = player.GetUsableCardsWithPaymentInformation();
                if (usableCards.Any())
                {
                    var dec = player.Choose(new CardUsageChoice(game.CurrentTurn.ActivePlayer, usableCards));
                    if (dec.Decision == null)
                    {
                        return true;
                    }
                    else
                    {
                        foreach (Card mana in dec.Decision.Manas.Select(x => game.GetCard(x)))
                        {
                            mana.Tapped = true;
                        }
                        game.UseCard(game.GetCard(dec.Decision.ToUse), game.GetPlayer(game.CurrentTurn.ActivePlayer));
                        return false;
                    }
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
