namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : Step
    {
        public ChargeStep(Player player) : base(player, "Charge")
        {
        }
    }
}
