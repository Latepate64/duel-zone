using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// To charge is to put a card from your hand into your mana zone, rotated 180 degrees from the normal position.
    /// </summary>
    public class ChargeMana : OptionalCardSelection<IHandCard>
    {
        internal ChargeMana(Player player) : base(player, new ReadOnlyCardCollection<IHandCard>(player.Hand.Cards))
        { }

        internal override PlayerAction Perform(Duel duel, IHandCard card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (card != null)
            {
                duel.PutFromHandIntoManaZone(Player, card);
            }
            return null;
        }
    }
}
