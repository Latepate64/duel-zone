using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
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

        internal override IPlayerAction PlayerActionRequired(IDuel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException(nameof(duel));
            }
            if (MustBeEnded || !ActivePlayer.Hand.Cards.Any())
            {
                return null;
            }
            else
            {
                MustBeEnded = true;
                return new ChargeMana(ActivePlayer);
            }
        }
    }
}
