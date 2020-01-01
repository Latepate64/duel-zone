using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may declare shield trigger to be used.
    /// </summary>
    public class DeclareShieldTriggers : MultipleCardSelection
    {
        internal DeclareShieldTriggers(Player player, ReadOnlyCardCollection cards) : base(player, cards)
        { }

        internal override PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards)
        {
            foreach (Card card in cards)
            {
                Player.AddShieldTriggerToUse(card);
            }
            return null;
        }
    }
}
