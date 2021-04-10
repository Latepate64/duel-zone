using DuelMastersModels.Cards;
using System.Collections.Generic;
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

        internal BreakShields(IPlayer player, int amount, IEnumerable<IShieldZoneCard> cards, IBattleZoneCreature shieldBreakingCreature) : base(player, amount, cards)
        {
            ShieldBreakingCreature = shieldBreakingCreature;
        }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
        {
            return duel.GetOpponent(Player).ShieldZone.Cards.Any(c => c.KnownToOpponent || c.KnownToOwner)
                ? Cards.Count() <= MaximumSelection ? Perform(duel, Cards) : (this)
                : Perform(duel, new ReadOnlyCollection<IShieldZoneCard>(Cards.ToList().GetRange(0, MinimumSelection)));
        }

        internal override IPlayerAction Perform(IDuel duel, IEnumerable<IShieldZoneCard> cards)
        {
            return duel.PutFromShieldZoneToHand(duel.GetOpponent(Player), cards, true);
        }
    }
}
