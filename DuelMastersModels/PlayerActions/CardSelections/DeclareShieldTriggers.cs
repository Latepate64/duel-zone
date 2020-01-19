using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may declare shield trigger to be used.
    /// </summary>
    public class DeclareShieldTriggers : MultipleCardSelection<IHandCard>
    {
        internal DeclareShieldTriggers(Player player, ReadOnlyCardCollection<IHandCard> cards) : base(player, cards)
        { }

        internal override PlayerAction Perform(Duel duel, ReadOnlyCardCollection<IHandCard> cards)
        {
            foreach (Card card in cards)
            {
                Player.AddShieldTriggerToUse(card);
            }
            return null;
        }
    }
}
