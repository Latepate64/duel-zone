﻿using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must choose which shields to break.
    /// </summary>
    public class BreakShields : MandatoryMultipleCardSelection<IShieldZoneCard>
    {
        /// <summary>
        /// Creature which is breaking shields.
        /// </summary>
        public IBattleZoneCreature ShieldBreakingCreature { get; private set; }

        internal BreakShields(Player player, int amount, ReadOnlyCardCollection<IShieldZoneCard> cards, IBattleZoneCreature shieldBreakingCreature) : base(player, amount, cards)
        {
            ShieldBreakingCreature = shieldBreakingCreature;
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return duel.GetOpponent(Player).ShieldZone.Cards.Any(c => c.KnownToOpponent || c.KnownToOwner)
                ? Cards.Count <= MaximumSelection ? Perform(duel, Cards) : (this)
                : Perform(duel, new ReadOnlyCardCollection<IShieldZoneCard>(Cards.ToList().GetRange(0, MinimumSelection)));
        }

        internal override PlayerAction Perform(Duel duel, ReadOnlyCollection<IShieldZoneCard> cards)
        {
            return duel.PutFromShieldZoneToHand(duel.GetOpponent(Player), cards, true);
        }
    }
}
