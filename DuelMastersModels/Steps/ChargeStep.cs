using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : Step
    {
        private bool _mustBeEnded = false;

        public ChargeStep(Player player) : base(player, "Charge")
        {
        }

        public override PlayerAction PlayerActionRequired()
        {
            if (_mustBeEnded || ActivePlayer.Hand.Cards.Count == 0)
            {
                return null;
            }
            else
            {
                _mustBeEnded = true;
                return new ChargeMana(ActivePlayer, ActivePlayer.Hand.Cards);
            }
        }
    }
}
