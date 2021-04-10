using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions.CardSelections;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    /// <summary>
    /// Player may choose a creature in the battle zone and return it to its owner's hand.
    /// </summary>
    public class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand : OptionalCardSelection<IBattleZoneCreature>
    {
        internal YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(IPlayer player, IEnumerable<IBattleZoneCreature> creatures) : base(player, creatures)
        { }

        public override IPlayerAction Perform(IDuel duel, IBattleZoneCreature card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else
            {
                return card == null ? null : duel.ReturnFromBattleZoneToHand(card);
            }
        }
    }
}
