using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal enum MainStepState
    {
        Use,
        Pay,
        MustBeEnded,
    }

    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main step.
    /// </summary>
    internal class MainStep : Step
    {
        internal MainStepState State { get; set; } = MainStepState.Use;

        internal Card CardToBeUsed { get; set; }

        internal MainStep(Player player) : base(player)
        {
        }

        internal override PlayerAction PlayerActionRequired(Duel duel)
        {
            ReadOnlyCardCollection usableCards = GetUsableCards(new ReadOnlyCardCollection(ActivePlayer.Hand.Cards), ActivePlayer.ManaZone.UntappedCards);
            if (State == MainStepState.Use && usableCards.Count > 0)
            {
                return new UseCard(ActivePlayer, usableCards);
            }
            else if (State == MainStepState.Pay)
            {
                return new PayCost(ActivePlayer, ActivePlayer.ManaZone.UntappedCards, CardToBeUsed.Cost);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the cards that can be used.
        /// </summary>
        private static ReadOnlyCardCollection GetUsableCards(ReadOnlyCardCollection handCards, ReadOnlyCardCollection manaCards)
        {
            return new ReadOnlyCardCollection(handCards.Where(handCard => Duel.CanBeUsed(handCard, manaCards)));
        }
    }
}
