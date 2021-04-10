﻿using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// To charge is to put a card from your hand into your mana zone, rotated 180 degrees from the normal position.
    /// </summary>
    public class ChargeMana : OptionalCardSelection<IHandCard>
    {
        internal ChargeMana(IPlayer player) : base(player, player.Hand.Cards)
        { }

        internal override PlayerAction Perform(Duel duel, IHandCard card)
        {
            if (card != null)
            {
                duel.PutFromHandIntoManaZone(Player, card);
            }
            return null;
        }
    }
}
