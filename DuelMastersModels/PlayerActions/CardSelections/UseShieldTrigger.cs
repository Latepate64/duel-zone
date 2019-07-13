﻿using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class UseShieldTrigger : MandatoryCardSelection
    {
        public UseShieldTrigger(Player player, Collection<Card> cards) : base(player, cards) { }

        public override PlayerAction Perform(Duel duel, Card card)
        {
            Player.Hand.Remove(card);
            duel.PlayCard(card, Player);
            Player.ShieldTriggersToUse.Remove(card);
            return null;
        }
    }
}