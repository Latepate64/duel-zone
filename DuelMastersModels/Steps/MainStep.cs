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

        internal IZoneCard CardToBeUsed { get; set; }

        internal MainStep(Player player) : base(player)
        {
        }

        internal override PlayerAction PlayerActionRequired(Duel duel)
        {
            ReadOnlyCardCollection<IHandCard> usableCards = GetUsableCards(new ReadOnlyCardCollection<IHandCard>(ActivePlayer.Hand.Cards), ActivePlayer.ManaZone.UntappedCards);
            return State == MainStepState.Use && usableCards.Count > 0
                ? new UseCard(ActivePlayer, usableCards)
                : (PlayerAction)(State == MainStepState.Pay ? new PayCost(ActivePlayer, ActivePlayer.ManaZone.UntappedCards, CardToBeUsed.Cost) : null);
        }

        /// <summary>
        /// Returns the cards that can be used.
        /// </summary>
        private static ReadOnlyCardCollection<IHandCard> GetUsableCards(ReadOnlyCardCollection<IHandCard> handCards, ReadOnlyCardCollection<IManaZoneCard> manaCards)
        {
            return new ReadOnlyCardCollection<IHandCard>(handCards.Where(handCard => Duel.CanBeUsed(handCard, manaCards)));
        }
    }
}
