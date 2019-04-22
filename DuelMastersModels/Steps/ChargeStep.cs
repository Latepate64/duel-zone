using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : Step
    {
        public bool MustBeEnded { get; set; } = false;

        public ChargeStep(Player player) : base(player)
        {
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (MustBeEnded || ActivePlayer.Hand.Cards.Count == 0)
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
