using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must use a shield trigger.
    /// </summary>
    public class UseShieldTrigger : MandatoryCardSelection<IHandCard>
    {
        internal UseShieldTrigger(Player player, ReadOnlyCardCollection<IHandCard> cards) : base(player, cards) { }

        internal override PlayerAction Perform(Duel duel, IHandCard card)
        {
            Player.Hand.Remove(card, duel);
            duel.UseCard(card);
            Player.RemoveShieldTriggerToUse(card);
            return null;
        }
    }
}
