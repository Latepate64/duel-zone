using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class UseShieldTrigger : MandatoryCardSelection
    {
        public UseShieldTrigger(Player player, ReadOnlyCardCollection cards) : base(player, cards) { }

        public override PlayerAction Perform(Duel duel, Card card)
        {
            Player.Hand.Remove(card, duel);
            duel.UseCard(card);
            Player.ShieldTriggersToUse.Remove(card);
            return null;
        }
    }
}
