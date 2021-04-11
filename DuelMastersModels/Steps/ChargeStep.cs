using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    internal class ChargeStep : Step
    {
        internal bool MustBeEnded { get; set; } = false;

        internal ChargeStep(IPlayer player) : base(player)
        {
        }

        public override IPlayerAction PlayerActionRequired(IDuel duel)
        {
            if (MustBeEnded || !ActivePlayer.Hand.Cards.Any())
            {
                return null;
            }
            else
            {
                MustBeEnded = true;
                IEnumerable<IHandCard> usableCards = MainStep.GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
                return new MainAction(ActivePlayer, ActivePlayer.Hand.Cards, usableCards, duel.GetCreaturesThatCanAttack(ActivePlayer));
            }
        }
    }
}
