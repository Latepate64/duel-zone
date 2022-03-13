﻿using Engine;
using System;
using System.Linq;

namespace Cards.Conditions
{
    /// <summary>
    /// Checks that filter produces no items.
    /// </summary>
    class FilterNoneCondition : Condition
    {
        internal FilterNoneCondition(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Game game, Guid player)
        {
            return !game.GetAllCards().Any(card => Filter.Applies(card, game, game.GetPlayer(player)));
        }

        public override string ToString()
        {
            return $"While any of {Filter} does not exist";
        }
    }
}