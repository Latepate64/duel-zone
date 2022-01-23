﻿using DuelMastersModels;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class PalaOlesisFilter : CardFilter
    {
        public PalaOlesisFilter()
        {
        }

        public PalaOlesisFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            // During your opponent's turn, each of your other creatures
            return card != null && game.CurrentTurn.NonActivePlayer == player.Id && game.BattleZone.GetCreatures(player.Id).Contains(card) && card.Id != Target;
        }

        public override CardFilter Copy()
        {
            return new PalaOlesisFilter(this);
        }
    }
}
