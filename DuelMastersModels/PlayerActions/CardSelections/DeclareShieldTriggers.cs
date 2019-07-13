using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class DeclareShieldTriggers : MultipleCardSelection
    {
        public DeclareShieldTriggers(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override PlayerAction Perform(Duel duel, Collection<Card> cards)
        {
            foreach (Card card in cards)
            {
                Player.ShieldTriggersToUse.Add(card);
            }
            return null;
        }
    }
}
