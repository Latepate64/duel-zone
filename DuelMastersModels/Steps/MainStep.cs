using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System.Collections.Generic;
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

        internal ICard CardToBeUsed { get; set; }

        internal MainStep(IPlayer player) : base(player)
        {
        }

        public override IChoice PlayerActionRequired(IDuel duel)
        {
            //IEnumerable<IHandCard> usableCards = GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
            throw new System.NotImplementedException();
            //return State == MainStepState.Use && usableCards.Any()
            //    ? new UseCard(ActivePlayer, usableCards)
            //    : (Choice)(State == MainStepState.Pay ? new PayCost(ActivePlayer, ActivePlayer.ManaZone.UntappedCards, CardToBeUsed.Cost) : null);
        }

        /// <summary>
        /// Returns the cards that can be used.
        /// </summary>
        public static IEnumerable<IHandCard> GetUsableCards(IEnumerable<IHandCard> handCards, IEnumerable<IManaZoneCard> manaCards)
        {
            return handCards.Where(handCard => Duel.CanBeUsed(handCard, manaCards));
        }
    }
}
